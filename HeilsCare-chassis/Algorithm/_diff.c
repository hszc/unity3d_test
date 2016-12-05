#include "stm32f10x.h"
#include "stm32f10x_conf.h"

#include "math.h"
#include "_typedef.h"
#include "_math.h"
#include "../Driver/_pwm.h"
#include "_mecanum.h"
#include "_delay.h"
struct diffWheel
{
	int port;				//��Ӧ��PWM�˿�
	int arg;				//����ϵ��
};


struct diffWheel leftWheel={1, 1};		//���ֵ�״̬����
struct diffWheel rightWheel={2, -1};

static float wheelWidth = 636.6;//�����������־�
static float wheelLength = 636.2;//ǰ���־�
static float wheelRadius = 50.0f;//�����ְ뾶

void setDiffSpeed(float speedTrans, float speedRot)
{
	/*���ٶ�*/
	float leftSpeed;
	float rightSpeed;
	
	float leftDelta;
	float rightDelta;

	float deltaMax = 0.0f;
	static float leftLast=0;	//�������ֵ��ٶ�
	static float rightLast=0;


	float delta_max;			//�ٶȱ仯�����ֵ
	float PWM_Max;				//���ɵ�PWM���Ӧ���ٶ����ֵ
	
	float pwmLeft, pwmRight;
	
	float transFactor = 1.0f;
	float rotFactor = 1.0f;
	
	leftSpeed = speedTrans * transFactor + speedRot * rotFactor * leftWheel.arg;
	rightSpeed = speedTrans * transFactor + speedRot * rotFactor * rightWheel.arg;
	
	leftDelta = leftSpeed - leftLast;
	rightDelta = rightSpeed - rightLast;

	deltaMax=Max(Abs(leftDelta),Abs(rightDelta));
	
	leftLast = leftSpeed;
	rightLast = rightSpeed;
	
	/**************************************************************************/	
 	pwmLeft = (Abs(leftSpeed) / 3000) * 90 + 10;
 	pwmRight = (Abs(rightSpeed) / 3000) * 90 + 10;

	if(pwmLeft > 95)
		pwmLeft = 95;
	if(pwmLeft < 5)
		pwmLeft = 5;
		
	if(pwmRight > 95)
		pwmRight = 95;
	if(pwmRight < 5)
		pwmRight = 5;

	if(leftSpeed > 0.0)
		GPIOA -> BSRR = GPIO_Pin_2;
	else 
		GPIOA ->BRR = GPIO_Pin_2;

	if(rightSpeed > 0.0)
		GPIOA -> BSRR = GPIO_Pin_3;
	else 
		GPIOA ->BRR = GPIO_Pin_3;
	delay_us(100);
	
	PWM_SetDuty(leftWheel.port,100 - pwmLeft);
 	PWM_SetDuty(rightWheel.port,100 - pwmRight);
}
/******************* (C) COPYRIGHT 2016 Heils *****END OF FILE****/
