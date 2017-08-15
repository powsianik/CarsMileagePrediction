﻿using System;
using CarsMileagePrediction.Steps;

namespace CarsMileagePrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            Step1();
            Step2();
            Step3();
            Step4();

            Console.ReadKey();
        }

        static void Step1()
        {
            Console.WriteLine("STEP 1: Shuffle data...");
            DataShuffle shuffle = new DataShuffle();
            shuffle.Shuffle(DataFilesInfoGetter.BaseFile, DataFilesInfoGetter.ShuffledBaseFile, true);
        }

        static void Step2()
        {
            Console.WriteLine("STEP 2: Segregate data...");
            DataSegregator segregator = new DataSegregator(75, 25);
            segregator.Segregate(DataFilesInfoGetter.ShuffledBaseFile, DataFilesInfoGetter.TrainingFile, DataFilesInfoGetter.EvaluateFile);
        }

        static void Step3()
        {
            Console.WriteLine("STEP 3: Normalize data...");
            DataNormalizer normalizer = new DataNormalizer();
            normalizer.Normalize(DataFilesInfoGetter.BaseFile, DataFilesInfoGetter.TrainingFile, DataFilesInfoGetter.NormalizedTrainingFile, DataFilesInfoGetter.EvaluateFile,
                DataFilesInfoGetter.NormalizedEvaluateFile, DataFilesInfoGetter.EncogAnalystFile);
        }

        static void Step4()
        {
            Console.WriteLine("STEP 4: Create neural network...");
            NetworkCreator networkCreator = new NetworkCreator();
            networkCreator.Create(DataFilesInfoGetter.NetworkFile);
        }
    }
}
