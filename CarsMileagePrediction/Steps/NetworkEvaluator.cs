using System;
using System.IO;
using Encog.App.Analyst;
using Encog.Neural.Networks;
using Encog.Persist;
using Encog.Util.CSV;
using Encog.Util.Simple;
using Encog.ML.Data.Basic;

namespace CarsMileagePrediction.Steps
{
    public class NetworkEvaluator
    {
        public void Evaluate(FileInfo networkFile, FileInfo analystFile, FileInfo EvaluationFile, FileInfo validationResultsFile)
        {
            var network = EncogDirectoryPersistence.LoadObject(networkFile) as BasicNetwork;
            var analyst = new EncogAnalyst();
            analyst.Load(analystFile);

            var evaluationSet = EncogUtility.LoadCSV2Memory(EvaluationFile.ToString(), network.InputCount,
                network.OutputCount, true, CSVFormat.English, false);

            using (var file = new StreamWriter(validationResultsFile.ToString()))
            {
                foreach (var item in evaluationSet)
                {
                    var normalizedActualOutput = (BasicMLData) network.Compute(item.Input);
                    var actualOutput = analyst.Script.Normalize.NormalizedFields[8]
                        .DeNormalize(normalizedActualOutput.Data[0]);
                    var idealOutput = analyst.Script.Normalize.NormalizedFields[8]
                        .DeNormalize(item.Ideal[0]);

                    file.WriteLine($"{idealOutput}, {actualOutput}");
                    Console.WriteLine($"Ideal: {idealOutput} | Actual: {actualOutput}");
                }
            }
        }
    }
}