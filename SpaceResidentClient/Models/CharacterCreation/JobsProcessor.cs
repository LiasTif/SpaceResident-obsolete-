using SpaceResidentClient.Properties;
using System.Collections.Generic;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal class JobsProcessor
    {
        /// <summary>
        /// List of all jobs in the game
        /// </summary>
        private static readonly List<string> _jobList =
        [
            Lang.unemployed,
            Lang.clerk,
            Lang.fleaMarketVendor,
            Lang.productionWorker
        ];

        public static List<string> GetJobList => _jobList;
    }
}