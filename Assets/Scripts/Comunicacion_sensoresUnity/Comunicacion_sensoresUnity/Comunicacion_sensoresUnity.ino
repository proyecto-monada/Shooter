int ldr = 0;
bool boton = 0;

void setup() {
  Serial.begin(9600);

  pinMode(A0, INPUT);
  pinMode(2, INPUT);
}

void loop() {
 

  ldr = analogRead(A0);
  boton = digitalRead(2);

  Serial.print(ldr);
  Serial.print(",");
  Serial.println(boton);
  //Serial.print(",\n");
  Serial.flush();



  delay(10);
}
