using System;
using System.Collections.Generic;
using FireAndForgetAudioSample;

namespace SoundOutfit
{
    class Sensor
    {
        CachedSound soundFile;
        int ID;
        int currentValue;
        int flexValue;
        public Sensor(string filePath, int sensorNum,int flexVal)
        {
            soundFile = new CachedSound(filePath);
            ID = sensorNum;
            flexValue = flexVal;
            currentValue = 0;
        }
        public int FlexValue
        {
            get
            {
                return flexValue;
            }
            set
            {
                flexValue = value;
            }
        }
        public int SensorValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }
        }
        public int SensorNumber
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public void parseValue(string input)
        {
            bool parsed = int.TryParse(input, out currentValue);
            if (parsed==false)
            {
                currentValue = 0;
            }
        }
        public bool isFlexed()
        {
            if(currentValue > flexValue)
            {
                return true;
            }
            return false;
        }

        public void playBeat()
        {
            AudioPlaybackEngine.Instance.PlaySound(soundFile);
        }
        public static void findCurrentSensor(ref int index,char ch)
        {
            switch (ch)
            {
                case '!':
                    index = 0;
                    break;

                case '@':
                    index = 1;
                    break;

                case '#':
                    index = 2;
                    break;

                case '$':
                    index = 3;
                    break;

                case '%':
                    index = 4;
                    break;

                default:
                    break;
            }
        }
        public static void printSensorValues(List<Sensor> sensorList,int iteration)
        {
            foreach (Sensor sensor in sensorList)
            {
                Console.WriteLine("Sensor {0} Value: {1}",sensor.ID,sensor.currentValue);
            }
            Console.WriteLine("______________________");
        }

    }
}
