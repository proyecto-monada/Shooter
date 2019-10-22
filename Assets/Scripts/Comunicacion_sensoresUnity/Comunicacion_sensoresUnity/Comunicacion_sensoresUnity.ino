<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> a65dd8b082a8ed31179da91d2b308892685da4bc
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
<<<<<<< HEAD
=======
=======
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
>>>>>>> cf512e1bcec256c971526caf826a03282bb7499f
>>>>>>> a65dd8b082a8ed31179da91d2b308892685da4bc
