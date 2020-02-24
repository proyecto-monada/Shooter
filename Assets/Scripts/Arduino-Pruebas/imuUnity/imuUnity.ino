#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>

#define NUM 50
#define GATILLO 8

/* This driver uses the Adafruit unified sensor library (Adafruit_Sensor),
   which provides a common 'type' for sensor data and some helper functions.

   To use this driver you will also need to download the Adafruit_Sensor
   library and include it in your libraries folder.

   You should also assign a unique ID to this sensor for use with
   the Adafruit Sensor API so that you can identify this particular
   sensor in any data logs, etc.  To assign a unique ID, simply
   provide an appropriate value in the constructor below (12345
   is used by default in this example).

   Connections
   ===========
   Connect SCL to analog 5
   Connect SDA to analog 4
   Connect VDD to 3-5V DC
   Connect GROUND to common ground

   History
   =======
   2015/MAR/03  - First release (KTOWN)
   2015/AUG/27  - Added calibration and system status helpers
*/

/* Set the delay between fresh samples */
#define BNO055_SAMPLERATE_DELAY_MS (50)

Adafruit_BNO055 bno = Adafruit_BNO055(55);

/********* IMU ************/
float x, y, z;              // Variables para la posición de la imu
float x_ant, y_ant, z_ant;  // Variables para la posición anterior de la imu
float x_inc, y_inc, z_inc;  // Incremento en cada eje
bool trigger = 0;

/********* GATILLO *******/
int gat_actual = 1;
int gat_ant = 1;
int trig = 0; // Se pone a 1 cuando pulsas, es lo que mandas


void init_orientacion () {
  //Los incrementos a 0
  //Leemos la IMU
  sensors_event_t event;
  bno.getEvent(&event);

  x = event.orientation.x;
  y = event.orientation.y;
  z = event.orientation.z;

  x_ant = x; y_ant = y; z_ant = z;

}

void setup(void) {

  Serial.begin(115200);
  pinMode(GATILLO, INPUT_PULLUP);

  /* Initialise the sensor */
  if (!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
    while (1);
  }

  bno.setExtCrystalUse(true);

  //Inicializamos la orientacion para que sea incremental
  init_orientacion();
}

void loop(void) {

  /*
                            IMU
     Para filtrar un poco los datos, leemos un numero NUM de veces
     de la imu y acumulamos su valor en las variables x, y, z y luego
     mandamos por serial los valores medios con 1 decimal
     SEPARADOS POR COMAS Y CON UN CARACTER DE CONTROL "#imu" AL PRINCIPIO
  */
  sensors_event_t event;

  for (int i = 0; i < NUM; i++) {
    // Estas dos líneas son para leer de la imu

    bno.getEvent(&event);

    // Acumulamos valores
    x += event.orientation.x;
    y += event.orientation.y;
    z += event.orientation.z;
  }
  x = x / NUM;
  y = y / NUM;

  // Mandamos por serial
  Serial.print("#imu");
  Serial.print(",");
  Serial.print(x, 1);
  Serial.print(",");
  Serial.println(y, 1);
  // Serial.print(",");
  // Serial.println(z / NUM, 1);

  delay(BNO055_SAMPLERATE_DELAY_MS);

  /* Ponemos las variables "medias" a 0
    para que no acumulen valores */
  x = 0;
  y = 0;
  z = 0;


  /*
              GATILLO
    Leemos del botón y lo mandamos por serial con UN CARACTER DE
    CONTROL "#b" AL PRINCIPIO Y SEPARADO POR UNA COMA
  */

  //Cuando pulsas da un 0, de normal es un 1
  //Gatillo: detector de flancos
  gat_actual = digitalRead(GATILLO);
  if (gat_actual == 0 && gat_ant == 1) {
    //Gatillo pulsado
    trig = 1;
    //Serial.println("GATILLO PULSADO");
  }
  else trig = 0;
  gat_ant = gat_actual;


  Serial.print("#trigg");
  Serial.print(",");
  Serial.println(trig);


  /*Salto de linea para iguiente loop*/
  // Serial.println("");

  // Serial.flush();




}
