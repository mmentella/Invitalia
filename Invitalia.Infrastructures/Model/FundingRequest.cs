using System.Collections.Generic;
using System.Linq;

namespace Invitalia.Infrastructures.Model
{
    public class FundingRequest
        : Core.Model.FundingRequest
    {
        private readonly List<OperatingUnit> operatingUnits;

        public FundingRequest()
        {
            operatingUnits = new List<OperatingUnit>();
        }

        public ScientificCoordinator ScientificCoordinator { get; set; }

        public void SetCoordinatoreScientifico(ScientificCoordinator scientificCoordinator)
        {
            ScientificCoordinator = scientificCoordinator;
            ScientificCoordinator.Bind(this);
        }

        public new OperatingUnit[] OperatingUnits
        {
            get { return operatingUnits.ToArray(); }
            set
            {
                operatingUnits.Clear();
                if (value == null || value.Length == 0) { return; }

                foreach (var unita in value.Where(u => u is not null))
                {
                    unita.Bind(this);
                }
                operatingUnits.AddRange(value);
            }
        }

        public void AddOperatingUnit(OperatingUnit unita)
        {
            unita.Bind(this);
            operatingUnits.Add(unita);
        }
    }
}
