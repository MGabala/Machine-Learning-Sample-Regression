// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace SampleRegression.ConsoleApp
{
    public partial class SampleRegression
    {
        /// <summary>
        /// model input class for SampleRegression.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"snapped_at")]
            public string Snapped_at { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"price")]
            public float Price { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"market_cap")]
            public float Market_cap { get; set; }

            [LoadColumn(3)]
            [ColumnName(@"total_volume")]
            public float Total_volume { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for SampleRegression.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"snapped_at")]
            public float[] Snapped_at { get; set; }

            [ColumnName(@"price")]
            public float Price { get; set; }

            [ColumnName(@"market_cap")]
            public float Market_cap { get; set; }

            [ColumnName(@"total_volume")]
            public float Total_volume { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("SampleRegression.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

    }
}
