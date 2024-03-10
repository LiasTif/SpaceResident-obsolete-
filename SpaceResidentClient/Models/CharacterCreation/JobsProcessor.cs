using SpaceResidentClient.Properties;
using System.Collections.Generic;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal class JobsProcessor
    {
        private static readonly List<string> _jobList =
        [
            Lang.unemployed,
            Lang.clerk,
            Lang.fleaMarketVendor,
            Lang.productionWorker
        ];

        internal static List<string> GetJobList => _jobList;
    }
}