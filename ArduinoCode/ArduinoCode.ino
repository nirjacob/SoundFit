
const int sensor1 = A0;
const int sensor2 = A1;
const int sensor3 = A2;
const int sensor5 = A3;
const int sensor4 = A4;
int flexValue1,flexValue2,flexValue3,flexValue4,flexValue5;

void setup() {
    Serial.begin(9600);
}

void loop() {
  flexValue1=analogRead(sensor1);
  Serial.println("!");
  Serial.println(flexValue1);
  
  flexValue2=analogRead(sensor2);
  Serial.println("@");
  Serial.println(flexValue2);
  
  flexValue3=analogRead(sensor3);
  Serial.println("#");
  Serial.println(flexValue3);
   
  flexValue4=analogRead(sensor4);
  Serial.println("$");
  Serial.println(flexValue4);
 
  flexValue5=analogRead(sensor5);
  Serial.println("%");
  Serial.println(flexValue5);
   
  delay(150);
}
