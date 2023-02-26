int button = 0;
int counter = 0;
int prev_state;
int ledState = LOW;

void setup() {
  pinMode(D0, INPUT_PULLDOWN_16);
  pinMode(D4, OUTPUT);
  digitalWrite(D4, LOW);
  button = digitalRead(D2);
}

void loop() {
  prev_state = button;
  //  button = digitalRead(D2);
  //if (prev_state == LOW && button == HIGH) {
  //  ledState = !ledState;
  //  digitalWrite(D4, ledState);
  //}
  //
  button = digitalRead(D2);
  if (button == HIGH) {
    counter += 1;
  }

  if (counter % 2 == 0) {
    digitalWrite(D4, LOW);
  } else {
    digitalWrite(D4, HIGH);
  }
  //
  //
  //  digitalWrite(D4, HIGH);
  //  delay(1000);
  //  digitalWrite(D4, LOW);
  //  delay(1000);
}
