/**********************************************************************
 *	@file: _gps.c
 *  @description: ȫ����λ�㷨
 *   
 *  @create: 2016-12-1
 *  @author: flysnow
 *  @explain: 
 *   
 *  @modification: 
 *  @author: 
 *  @explain: 
 *********************************************************************/  
 
 
#include "stm32f10x.h"
#include "stm32f10x_tim.h"
#include "../Driver/_delay.h"
#include <math.h>
#include "_math.h"

#define ENCODER_NUM 2
#define LEFT_TAG 0
#define RIGHT_TAG 1

#define GPS_NUM 2
#define NOW 0
#define LAST 1
#define CAR_WIDTH 20

typedef struct 
{
	float x;
	float y;
}tPoint;

typedef struct 
{   
	tPoint  						position;	  	  //��ǰ����	
	float				        stepLeft; 	//����1����ǰ������
	float				        stepRight;  //����2����ǰ������
	float			          disLeft;	  	//����1ǰ������
	float			        	disRight;		  //����2ǰ������
	float  	        		angle;        	//��ǰ�Ƕ� 		
	float				        radian;			    //��ǰ����
	float				        speed;			    //��ǰ�ٶ�
	float				        acceleration;	  //��ǰ���ٶ�
	float			         	rotationspeed;	//��ǰ��ת�ٶ�
	float				        rotationacc;	  //��ǰ��ת���ٶ�
}tGps;


struct sEncoder
{
	float lastCount;			//��һ�ε��������
	float totalCount;			//�ܹ��������
	float realDis;				//ʵ�ʾ���
	float convertFactor[2];		//[0]��תϵ��[1]��תϵ��
	float r;				//������תʱ���̵���ת�뾶
	float dir;			//����
	float radian;			//�����복������ϵY��������ļн�
};

//ȫ����λ��Ϣ�ṹ��
struct sGps
{
	tPoint position;	//
	float radian;			//����
};

tGps gpsList[2];

struct sEncoder Encoders[2]=
{
	
	{0, 0, 0, {1, 1}, 0, -1, 0.0},
	{0, 0, 0, {1, 1}, 0, -1, 0.0},
};

void gpsUpdate(void)
{
	
	float x_deta = 0;
	float y_deta = 0;
	float theta_deta = 0;
	float R = 0;
	float L = 0;
 	float radian = 0;

	gpsList[1] = gpsList[0];
	gpsList[0].disLeft = Encoders[0].realDis;
	gpsList[0].disRight = Encoders[1].realDis;
	
 	gpsList[0].stepLeft = gpsList[0].disLeft - gpsList[1].disLeft;
 	gpsList[0].stepRight = gpsList[0].disRight - gpsList[1].disRight; 
	
	if(gpsList[0].stepLeft == gpsList[0].stepRight )
	{
		theta_deta = 0;
		x_deta = (gpsList[0].stepLeft + gpsList[0].stepRight) / 2 * cos(pi / 2 - gpsList[0].radian);			
		y_deta = (gpsList[0].stepLeft + gpsList[0].stepRight) / 2 * sin(pi / 2 - gpsList[0].radian);
	}
	else
	{
		theta_deta = (gpsList[0].stepLeft - gpsList[0].stepRight) / CAR_WIDTH;
		R = (gpsList[0].stepLeft + gpsList[0].stepRight) / (2 * theta_deta) ; 
		L = sin(theta_deta / 2) * R * 2;
	// 			x_deta=cos(pi/2-gpsList[0].radian-theta_deta/2)*L;
		x_deta = R * cos(-gpsList[0].radian) - R * cos(-(gpsList[0].radian + theta_deta));
		y_deta = sin(pi / 2 - gpsList[0].radian - theta_deta / 2) * L;
	}
	gpsList[0].radian += theta_deta;
	if(gpsList[0].radian > 2*pi)
		gpsList[0].radian -= 2*pi;
	if(gpsList[0].radian < -2*pi)
		gpsList[0].radian += 2*pi;
	gpsList[0].angle = 180*gpsList[0].radian / pi;

	gpsList[0].position.x += x_deta;
	gpsList[0].position.y += y_deta;

}


void Encoder_Clear(u8 index)
{
	Encoders[index].lastCount = 0;	
	Encoders[index].totalCount = 0;
	Encoders[index].realDis=0.0;

}

void gpsInit(tPoint position,float radian)
{
	int iCount;
	Encoder_Clear(0);
	Encoder_Clear(1);
	for(iCount = 0;iCount < GPS_NUM;iCount++)
	{
		gpsList[iCount].disLeft = 0.0;
		gpsList[iCount].disRight = 0.0;
		gpsList[iCount].stepLeft = 0.0;
		gpsList[iCount].stepRight = 0.0;
		gpsList[iCount].position = position;
		gpsList[iCount].angle = radian / pi * 180.0;
		gpsList[iCount].radian = radian;
		gpsList[iCount].speed = 0.0;
		gpsList[iCount].acceleration = 0.0;
	}
}
