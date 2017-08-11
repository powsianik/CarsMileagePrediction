using System;
using CarsMileagePrediction.Steps;

namespace CarsMileagePrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            Step1();
        }

        static void Step1()
        {
            Console.WriteLine("STEP 1: Shuffle data...");
            DataShuffle shuffle = new DataShuffle();
            shuffle.Shuffle(DataFilesInfoGetter.BaseFile, DataFilesInfoGetter.ShuffledBaseFile, true);
        }
    }
}
