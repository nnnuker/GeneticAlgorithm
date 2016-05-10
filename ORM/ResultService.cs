using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ORM
{
    public static class ResultService
    {
        #region Fields

        private static readonly DatabaseEntities databaseEntities;
        private static int populationId;
        private static int crossoverId;
        private static int descendantsId;
        private static int selectPointsId;
        private static int pairFormationId;

        #endregion

        static ResultService()
        {
            databaseEntities = new DatabaseEntities();
            populationId = 1;
            crossoverId = 1;
            descendantsId = 1;
            selectPointsId = 1;
            pairFormationId = 1;
        }

        public static DatabaseEntities Instance => databaseEntities;

        #region Public methods

        public static void AddResult(int populationId, int crossoverId, int descendantsId,
            int selectPointsId, int pairFormationId)
        {
            if (populationId <= 0) populationId = 1;
            if (crossoverId <= 0) crossoverId = 1;
            if (descendantsId <= 0) descendantsId = 1;
            if (selectPointsId <= 0) selectPointsId = 1;
            if (pairFormationId <= 0) pairFormationId = 1;

            ResultService.populationId = populationId;
            ResultService.crossoverId = crossoverId;
            ResultService.descendantsId = descendantsId;
            ResultService.selectPointsId = selectPointsId;
            ResultService.pairFormationId = pairFormationId;
        }

        public static void SaveResult(double functionValue)
        {
            databaseEntities.Set<Result>().Add(new Result
            {
                CrossoverId = crossoverId,
                PopulationId = populationId,
                DescendantsId = descendantsId,
                SelectPointsId = selectPointsId,
                PairFormationId = pairFormationId,
                FunctionValue = Convert.ToSingle(functionValue)
            });

            databaseEntities.SaveChanges();
        }

        public static List<Population> GetPopulations()
        {
            return databaseEntities.Populations.ToList();
        }

        public static List<Crossover> GetCrossovers()
        {
            return databaseEntities.Crossovers.ToList();
        }

        public static List<SelectPoint> GetSelectPoints()
        {
            return databaseEntities.SelectPoints.ToList();
        }

        public static List<Descendant> GetDescendants()
        {
            return databaseEntities.Descendants.ToList();
        }

        public static List<PairFormation> GetPairFormations()
        {
            return databaseEntities.PairFormations.ToList();
        }

        public static List<Result> GetResults()
        {
            return databaseEntities.Results.ToList();
        }

        #endregion

    }
}