
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
    
  delay(10);
}
=======
  delay(50);
}

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

