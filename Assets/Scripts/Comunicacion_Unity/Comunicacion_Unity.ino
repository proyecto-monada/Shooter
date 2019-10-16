<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> fe7221612b3742f41510e876eeb0fc54f46f7f78
int msg1 = 0;
int msg2 = 1000;

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.flush();

  Serial.print(msg1);
  Serial.print(",");
  Serial.println(msg2);

  msg1++;
  msg2--;
  if (msg1 >= 1000){
    msg1 = 0;
    msg2 = 1000;
  }
    
  delay(50);
}
<<<<<<< HEAD
=======
=======
int msg1 = 0;
int msg2 = 1000;

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.flush();

  Serial.print(msg1);
  Serial.print(",");
  Serial.println(msg2);

  msg1++;
  msg2--;
  if (msg1 >= 1000){
    msg1 = 0;
    msg2 = 1000;
  }
    
  delay(50);
}
>>>>>>> cf512e1bcec256c971526caf826a03282bb7499f
>>>>>>> fe7221612b3742f41510e876eeb0fc54f46f7f78
