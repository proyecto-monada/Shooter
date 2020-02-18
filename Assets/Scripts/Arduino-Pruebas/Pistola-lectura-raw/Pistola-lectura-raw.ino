#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>

//Botones pistola
#define DERECHA     A2
#define RETROCESO   A3
#define IZQUIERDA   2
#define CARGAR      3
#define VIBRACION   4
#define MENU        5
#define ARRIBA      6
#define ABAJO       7
#define GATILLO     8

//IMU
/*   Connections
   ===========
   Connect SCL to A5
   Connect SDA to A4
   Connect VDD to 3-5V DC
   Connect GROUND to common ground
*/
#define BNO055_SAMPLERATE_DELAY_MS (100)
Adafruit_BNO055 bno = Adafruit_BNO055(55);

void setup(){
  Serial.begin(9600);
  //Botones
  pinMode(GATILLO, INPUT_PULLUP);
  pinMode(ARRIBA, INPUT_PULLUP);
  pinMode(ABAJO, INPUT_PULLUP);
  pinMode(DERECHA, INPUT_PULLUP);
  pinMode(IZQUIERDA, INPUT_PULLUP);
  pinMode(MENU, INPUT_PULLUP);
  pinMode(CARGAR, INPUT_PULLUP);
  //IMU
  if (!bno.begin()){
  /* There was a problem detecting the BNO055 ... check your connections */
  Serial.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
  while (1);
  }
  delay(1000);
  bno.setExtCrystalUse(true);
}

void loop(){
  //Botones
  Serial.println();
  Serial.print(digitalRead(GATILLO));
  Serial.print(digitalRead(MENU));
  Serial.print(digitalRead(CARGAR));
  Serial.print(digitalRead(ARRIBA));
  Serial.print(digitalRead(ABAJO));
  Serial.print(digitalRead(DERECHA));
  Serial.println(digitalRead(IZQUIERDA));
  
  //IMU
  /* Get a new sensor event */
  sensors_event_t event;
  bno.getEvent(&event);
  /* Display the floating point data */
  Serial.println();
  Serial.print("x: ");
  Serial.print(event.orientation.x, 4);
  Serial.print("  y:");
  Serial.print(event.orientation.y, 4);
  Serial.print("  z:");
  Serial.print(event.orientation.z, 4);
  delay(BNO055_SAMPLERATE_DELAY_MS);
}

     
