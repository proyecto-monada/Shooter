
#include <Wire.h>

#define DERECHA     A2
#define RETROCESO   A3
#define IZQUIERDA   2
#define CARGAR      3
#define VIBRACION   4
#define MENU        5
#define ARRIBA      6
#define ABAJO       7
#define GATILLO     8



bool ult;
unsigned long TiempoUltimo = 0;



ISR(TIMER1_COMPA_vect){
    digitalWrite(VIBRACION,LOW);
    TIMSK1 = 0b00000000;
}



void setup(){
  Serial.begin(9600);
  pinMode(GATILLO, INPUT_PULLUP);
  pinMode(ARRIBA, INPUT_PULLUP);
  pinMode(ABAJO, INPUT_PULLUP);
  pinMode(DERECHA, INPUT_PULLUP);
  pinMode(IZQUIERDA, INPUT_PULLUP);
  pinMode(MENU, INPUT_PULLUP);
  pinMode(CARGAR, INPUT_PULLUP);
  
  pinMode(VIBRACION, OUTPUT);
  //pinMode(RETROCESO, OUTPUT);

  digitalWrite(GATILLO, HIGH);
  digitalWrite(ARRIBA, HIGH);
  digitalWrite(ABAJO, HIGH);
  digitalWrite(DERECHA, HIGH);
  digitalWrite(IZQUIERDA, HIGH);
  digitalWrite(MENU, HIGH);
  ult = LOW;

  digitalWrite(VIBRACION, HIGH);
  //digitalWrite(RETROCESO, HIGH);
  delay(2000);
  digitalWrite(VIBRACION, LOW);
  //digitalWrite(RETROCESO, LOW);

//
  TCCR1A = 0b00000011;  //OC1A y OC1A desconectados, WGM11 WGM10
  TCCR1B = 0b00011010;  //WGM13 WGM12 ; CS12 CS11 CS10 para el  preescaler
  //WGM = 1111 => Fast PWM con OCR1A como TOP
  OCR1A = 20000;
  TIMSK1 = 0b00000000;  //OCIE1A Output Compare B Match Interrupt Enable
  sei();
}




void loop(){
  if(digitalRead(GATILLO) && !ult && millis()-TiempoUltimo>10){
    ult = HIGH;
    TiempoUltimo = millis();
    digitalWrite(VIBRACION, HIGH);
    TIMSK1 = 0b00000010;
  }
  if(millis()-TiempoUltimo>10 && !digitalRead(GATILLO)) ult=LOW;

  Serial.print(digitalRead(GATILLO));
  Serial.print(digitalRead(MENU));
  Serial.print(digitalRead(CARGAR));
  Serial.print(digitalRead(ARRIBA));
  Serial.print(digitalRead(ABAJO));
  Serial.print(digitalRead(DERECHA));
  Serial.println(digitalRead(IZQUIERDA));
  delay(5);
}

     
