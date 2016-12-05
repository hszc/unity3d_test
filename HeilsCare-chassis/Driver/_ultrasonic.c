
/**********************************************************************
 *	@file: _ultrasonic.c
 *  @description: 超声波测距
 *   
 *  @create: 2016-8-2
 *  @author: flysnow
 *  @explain: 4组超声波
 *   
 *  @modification: 2016-12-1
 *  @author: flysnow
 *  @explain: 修改注释
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
		
		.GPIO_IN								= GPIOC,
		.Pin_In 								= GPIO_Pin_0,
		.GPIO_OUT								= GPIOD,
		.Pin_Out								= GPIO_Pin_12,

		.trigfactor 						= 4.5,
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
		
		.GPIO_IN								= GPIOC,
		.Pin_In 								= GPIO_Pin_1,
		.GPIO_OUT								= GPIOD,
		.Pin_Out								= GPIO_Pin_13,

		.trigfactor 						= 4.5,
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
		
		.GPIO_IN								= GPIOC,
		.Pin_In 								= GPIO_Pin_2,
		.GPIO_OUT								= GPIOD,
		.Pin_Out								= GPIO_Pin_14,

		.trigfactor 						= 4.5,
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
		
		.GPIO_IN								= GPIOC,
		.Pin_In 								= GPIO_Pin_3,
		.GPIO_OUT								= GPIOD,
		.Pin_Out								= GPIO_Pin_15,

		.trigfactor 						= 4.5,
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
 * 	@description:超声波测距中可能出现噪声，修正的阿尔法滤波器有效的降噪
 *  @param: parg通道编号
 *  @return:
 ************************************************************************/ 
static void ClcUtralData(unsigned char parg)
{
	Ultrasonic[parg].distance = 0.0f;
	Ultrasonic[parg].trig_time = 0;
}

/************************************************************************
 * 	@function:UtralMea
 * 	@description:超声波测量前需要向超声波模块发送脉冲
 *  @param: parg通道编号
 *  @return:
 ************************************************************************/
static void UtralMea(unsigned char parg)
{
	Ultrasonic[parg].GPIO_OUT -> BSRR = Ultrasonic[parg].Pin_Out;
	delay_ms(2);
	Ultrasonic[parg].GPIO_OUT -> BRR = Ultrasonic[parg].Pin_Out;
	Ultrasonic[parg].IsStart = 1;
}

/************************************************************************
 * 	@function:Ultrafilter
 * 	@description:超声波测距中可能出现噪声，修正的阿尔法滤波器有效的降噪
 *  @param: parg通道编号
 *  @return:
 ************************************************************************/ 
static int l_cnt = 0;
static float distanceDataIn[4][TOTAL] = {0};
static float distanceDataTmp[4][TOTAL] = {0};
static int m_cnt = 0;
static float distanceSum = 0;
static void Ultrafilter(unsigned char parg)
{
		//滑动窗口卷积
		for(l_cnt = 1; l_cnt < TOTAL; l_cnt++)
		{
			distanceDataIn[Ultrasonic[parg].Id][l_cnt - 1] = distanceDataIn[Ultrasonic[parg].Id][l_cnt];
		}
		distanceDataIn[Ultrasonic[parg].Id][TOTAL - 1] = Ultrasonic[parg].distance;
		//将distanceData数组里的数据移到暂存数组里面
		for(l_cnt = 1; l_cnt < TOTAL; l_cnt++)
		{
			distanceDataTmp[Ultrasonic[parg].Id][l_cnt] = distanceDataIn[Ultrasonic[parg].Id][l_cnt];
		}
		//对暂存数组进行冒泡排序
		bubble_sort(distanceDataTmp[Ultrasonic[parg].Id], TOTAL);
		//对中间MEAN个数求均值
		for(m_cnt = 0; m_cnt < MEAN; m_cnt++)
		{
			distanceSum += distanceDataTmp[Ultrasonic[parg].Id][TOTAL / 2 + m_cnt - SIDE];
		}
		Ultrasonic[parg].filterdistance = distanceSum / MEAN;
		distanceSum = 0;

}


/************************************************************************
 * 	@function:bubble_sort
 * 	@description:冒泡排序
 *  @param: a--数组，n--数组元素个数
 *  @return:
 ************************************************************************/ 
void bubble_sort(float a[], u8 n)
{
	u8 i,j;
	float tmp;
	for (i=n-1; i>0; i--)
	{
		// 将a[0...i]中最大的数据放在末尾
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
