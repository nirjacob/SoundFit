using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using FireAndForgetAudioSample;

namespace SoundOutfit
{
    static class Program
    {
        static void Main()
        {
            // Arduino print format:
            //              !<Sensor1_value>@<Sensor2_value>857#<Sensor3_value>$<Sensor4_value>%<Sensor5_value>
            // example:     !942@0#0$12%932              
            // I used symbol indicators to save up on bits per loop.                
            List<Sensor> sensorList = new List<Sensor>();
            int globalFlexValue = 400;
            sensorList.Add(new Sensor("closed-hat-trimmed.wav", 1, globalFlexValue));
            sensorList.Add(new Sensor("crash-trimmed.wav", 2, globalFlexValue));
            sensorList.Add(new Sensor("kick-trimmed.wav", 3, globalFlexValue));
            sensorList.Add(new Sensor("open-hat-trimmed.wav", 4, globalFlexValue));
            sensorList.Add(new Sensor("snare-trimmed.wav", 5, globalFlexValue));
            int iteration = 0;
            SerialPort arduinoPort = new SerialPort("COM4",9600);
            arduinoPort.Open();
            while (arduinoPort.IsOpen)
            {
                string arduinoData = arduinoPort.ReadExisting();
                string sensorsData = string.Empty;
                bool numberFound = false;
                int currentSensor = 0;
                for (int i = 0; i < arduinoData.Length; i++)
                {
                    Sensor.findCurrentSensor(ref currentSensor, arduinoData[i]);
                    if (Char.IsDigit(arduinoData[i]))
                    {
                        sensorsData += arduinoData[i];
                        numberFound = true;
                    }
                    if (numberFound && Char.IsDigit(arduinoData[i]) == false)
                    {
                        sensorList[currentSensor].parseValue(sensorsData);
                        if (sensorList[currentSensor].isFlexed())
                        {
                            sensorList[currentSensor].playBeat();
                        }
                        sensorsData = string.Empty;
                        numberFound = false;
                    }
                }
                iteration++;
                Sensor.printSensorValues(sensorList, iteration % 20);
                Thread.Sleep(20);
            }
            AudioPlaybackEngine.Instance.Dispose();
        }
    }
}

