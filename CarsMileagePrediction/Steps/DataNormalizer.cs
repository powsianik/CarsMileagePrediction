using System.IO;
using Encog.App.Analyst;
using Encog.App.Analyst.CSV.Normalize;
using Encog.App.Analyst.Wizard;
using Encog.Util.Arrayutil;
using Encog.Util.CSV;

namespace IrisPlantClassification.Steps
{
    public class DataNormalizer
    {
        public void Normalize(FileInfo baseFile, FileInfo trainingFile, FileInfo normalizedTrainingFile, FileInfo evaluateFile, FileInfo normalizedEvaluateFile, FileInfo analystFile)
        {
            var encogAnalyst = new EncogAnalyst();
            var analystWizard = new AnalystWizard(encogAnalyst);
            analystWizard.Wizard(baseFile, true, AnalystFileFormat.DecpntComma);

            //Cylinders:
            encogAnalyst.Script.Normalize.NormalizedFields[0].Action = NormalizationAction.Equilateral;
            //Displacement:
            encogAnalyst.Script.Normalize.NormalizedFields[1].Action = NormalizationAction.Normalize;
            //Horsepower:
            encogAnalyst.Script.Normalize.NormalizedFields[2].Action = NormalizationAction.Normalize;
            //Weight:
            encogAnalyst.Script.Normalize.NormalizedFields[3].Action = NormalizationAction.Normalize;
            //Acceleration:
            encogAnalyst.Script.Normalize.NormalizedFields[4].Action = NormalizationAction.Normalize;
            //Year:
            encogAnalyst.Script.Normalize.NormalizedFields[5].Action = NormalizationAction.Equilateral;
            //Origin:
            encogAnalyst.Script.Normalize.NormalizedFields[6].Action = NormalizationAction.Equilateral;
            //Name:
            encogAnalyst.Script.Normalize.NormalizedFields[7].Action = NormalizationAction.Ignore;
            //Mpg:
            encogAnalyst.Script.Normalize.NormalizedFields[8].Action = NormalizationAction.Normalize;

            var normalizer = new AnalystNormalizeCSV();
            normalizer.Analyze(trainingFile, true, CSVFormat.English, encogAnalyst);
            normalizer.ProduceOutputHeaders = true;
            normalizer.Normalize(normalizedTrainingFile);

            normalizer.Analyze(evaluateFile, true, CSVFormat.English, encogAnalyst);
            normalizer.Normalize(normalizedEvaluateFile);

            encogAnalyst.Save(analystFile);
        }
    }
}