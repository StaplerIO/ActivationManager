# Project ActivationManager

## Goal

- Generate random machine identifier
- Verify serial code by verification algorithm
- Send data to server to save license credential



## Process

### On application start

- Generate random machine identifier
- Load window
- Check if the machine has already verified

### Button "Activate" clicked

- Read local network interface MAC address

- Send MAC address to server

- Check serial code online (server side)

  ### Server Side

  - Receive data
  - Check serial code

