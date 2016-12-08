
/**********************************************************************
 *	@file: _ultrasonic.c
 *  @description: ���������
 *   
 *  @create: 2016-8-2
 *  @author: flysnow
 *  @explain: 4�鳬����
 *   
 *  @modification: 2016-12-1
 *  @author: flysnow
 *  @explain: �޸�ע��
 *********************************************************************/  
 
 
#include "stm32f10x.h"
#include "stm32f10x_tim.h"
#include "../Driver/_io_status.h"
#include "../Driver/_delay.h"
#include "../Driver/_ultrasonic.h"

static void ClcUtralData(unsigned char parg);

static void UtralMea(unsigned char parg);

static void Ultrafilter(unsigned char parg);


struct Ultrasonic Ultrasonic[] =
{
	{
		.Id 										= 0x00,
		.trig_time   						= 0,
		.cnt                    = 0,
	  .trig_count							= 0,
		.GPIO_IN								= GPIOC,
		.Pin_In 								= GPIO_Pin_0,
		.GPIO_OUT								= GPIOD,
		.Pin_Out								= GPIO_Pin_12,

		.trigfactor 						= 0.017,//340 / 2 / 10000,
		.distance 							=	0.0f,
		.IsStop 								= 1,
		.threthold 							= 200,
		.IsStart 								= 0,
		.filterdistance         = 0,
		.ClcUtralData 					= ClcUtralData,
		.UtralMea 							= UtralMea,
		.Ultrafilter            = Ultrafilter,
	},
	{
		.Id 										= 0x01,
		.trig_time   						= 0,
		.cnt                    = 0,
	  .trig_count							= 0,
		.GPIO_IN								= GPIOC,
		.Pin_In 								= GPIO_Pin_1,
		.GPIO_OUT								= GPIOD,
		.Pin_Out								= GPIO_Pin_13,

		.trigfactor 						= 0.017,
		.distance 							=	0.0f,
		.IsStop 								= 1,
		.threthold 							= 200,
		.IsStart 								= 0,
		.filterdistance         = 0,
		.ClcUtralData 					= ClcUtralData,
		.UtralMea 							= UtralMea,
		.Ultrafilter            = Ultrafilter,
	},
	{
		.Id 										= 0x02,
		.trig_time   						= 0,
		.cnt                    = 0,
	  .trig_count							= 0,
		.GPIO_IN								= GPIOC,
		.Pin_In 								= GPIO_Pin_2,
		.GPIO_OUT								= GPIOD,
		.Pin_Out								= GPIO_Pin_14,

		.trigfactor 						= 0.017,
		.distance 							=	0.0f,
		.IsStop 								= 1,
		.threthold 							= 200,
		.IsStart 								= 0,
		.filterdistance         = 0,
		.ClcUtralData 					= ClcUtralData,
		.UtralMea 							= UtralMea,
		.Ultrafilter            = Ultrafilter,
	},
	{
		.Id 										= 0x03,
		.trig_time   						= 0,
		.cnt                    = 0,
	  .trig_count							= 0,
		.GPIO_IN								= GPIOC,
		.Pin_In 								= GPIO_Pin_3,
		.GPIO_OUT								= GPIOD,
		.Pin_Out								= GPIO_Pin_15,

		.trigfactor 						= 0.017,
		.distance 							=	0.0f,
		.IsStop 								= 1,
		.threthold 							= 200,
		.IsStart 								= 0,
		.filterdistance         = 0,
		.ClcUtralData 					= ClcUtralData,
		.UtralMea 							= UtralMea,
		.Ultrafilter            = Ultrafilter,
	},
};

unsigned char ultrasonic_num = sizeof(Ultrasonic)/sizeof(Ultrasonic[0]);

/************************************************************************
 * 	@function:ClcUtralData
 * 	@description:����������п��ܳ��������������İ������˲�����Ч�Ľ���
 *  @param: pargͨ�����
 *  @return:
 ************************************************************************/ 
static void ClcUtralData(unsigned char parg)
{
	Ultrasonic[parg].distance = 0.0f;
	Ultrasonic[parg].trig_time = 0;
}

/************************************************************************
 * 	@function:UtralMea
 * 	@description:����������ǰ��Ҫ������ģ�鷢������
 *  @param: pargͨ�����
 *  @return:
 ************************************************************************/
static void UtralMea(unsigned char parg)
{
	Ultrasonic[parg].GPIO_OUT -> BSRR = Ultrasonic[parg].Pin_Out;
	delay_us(20);
	Ultrasonic[parg].GPIO_OUT -> BRR = Ultrasonic[parg].Pin_Out;
	
	/*�ȴ������ź�*/

	while(GPIO_ReadInputDataBit(Ultrasonic[parg].GPIO_IN,Ultrasonic[parg].Pin_In) == RESET);
	TIM_Cmd(TIM4,ENABLE);
	//�����źŵ�����������ʱ������
	Ultrasonic[parg].IsStart = 0x01;
	while(GPIO_ReadInputDataBit(Ultrasonic[parg].GPIO_IN,Ultrasonic[parg].Pin_In) == SET);
	//�����ź���ʧ
	TIM_Cmd(TIM4,DISABLE);
	//�رն�ʱ��

	Ultrasonic[parg].cnt = TIM4->CNT;
	//��ȡ��TIM2���Ĵ����еļ���ֵ��һ�߼�������ź�ʱ��
	Ultrasonic[parg].trig_time = Ultrasonic[parg].cnt + Ultrasonic[parg].trig_count * 399;
	Ultrasonic[parg].distance = (float)Ultrasonic[parg].trig_time * Ultrasonic[parg].trigfactor;
	//ͨ�������źż������
	TIM4->CNT = 0;  //��TIM2�����Ĵ����ļ���ֵ����
	Ultrasonic[parg].IsStart = 0x00;	
	Ultrasonic[parg].trig_count = 0;  //�ж������������
	delay_ms(10);
}

/************************************************************************
 * 	@function:Ultrafilter
 * 	@description:����������п��ܳ��������������İ������˲�����Ч�Ľ���
 *  @param: pargͨ�����
 *  @return:
 ************************************************************************/ 
static int l_cnt = 0;
static float distanceDataIn[4][TOTAL] = {0};
static float distanceDataTmp[4][TOTAL] = {0};
static int m_cnt = 0;
static float distanceSum = 0;
static void Ultrafilter(unsigned char parg)
{
		//�������ھ��
		for(l_cnt = 1; l_cnt < TOTAL; l_cnt++)
		{
			distanceDataIn[Ultrasonic[parg].Id][l_cnt - 1] = distanceDataIn[Ultrasonic[parg].Id][l_cnt];
		}
		distanceDataIn[Ultrasonic[parg].Id][TOTAL - 1] = Ultrasonic[parg].distance;
		//��distanceData������������Ƶ��ݴ���������
		for(l_cnt = 1; l_cnt < TOTAL; l_cnt++)
		{
			distanceDataTmp[Ultrasonic[parg].Id][l_cnt] = distanceDataIn[Ultrasonic[parg].Id][l_cnt];
		}
		//���ݴ��������ð������
		bubble_sort(distanceDataTmp[Ultrasonic[parg].Id], TOTAL);
		//���м�MEAN�������ֵ
		for(m_cnt = 0; m_cnt < MEAN; m_cnt++)
		{
			distanceSum += distanceDataTmp[Ultrasonic[parg].Id][TOTAL / 2 + m_cnt - SIDE];
		}
		Ultrasonic[parg].filterdistance = distanceSum / MEAN;
		distanceSum = 0;

}


/************************************************************************
 * 	@function:bubble_sort
 * 	@description:ð������
 *  @param: a--���飬n--����Ԫ�ظ���
 *  @return:
 ************************************************************************/ 
void bubble_sort(float a[], u8 n)
{
	u8 i,j;
	float tmp;
	for (i=n-1; i>0; i--)
	{
		// ��a[0...i]���������ݷ���ĩβ
		for (j=0; j<i; j++)
		{
			if (a[j] > a[j+1])
			{
				tmp = a[j];
				a[j] = a[j + 1];
				a[j + 1] = tmp;
			}
		}
	}
}


/******************* (C) COPYRIGHT 2016 Heils *****END OF FILE****/
