using System.IO;

namespace CarsMileagePrediction
{
    public class DataFilesInfoGetter
    {
        public static FileInfo BasePath = new FileInfo($@"{Directory.GetCurrentDirectory().Replace(@"CarsMileagePrediction\bin\Debug", string.Empty)}Data\");

        public static FileInfo BaseFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "AutoMPG.csv"));

        public static FileInfo ShuffledBaseFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "AutoMPG_Shuffled.csv"));

        public static FileInfo TrainingFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "AutoMPG_Training.csv"));

        public static FileInfo EvaluateFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "AutoMPG_Evaluate.csv"));

        public static FileInfo NormalizedTrainingFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "AutoMPG_NormalizedTraining.csv"));

        public static FileInfo NormalizedEvaluateFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "AutoMPG_NormalizedEvaluate.csv"));

        public static FileInfo EncogAnalystFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "AutoMPG_EncogAnalyst.ega"));

        public static FileInfo NetworkFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "AutoMPG_Network.eg"));
    }
}