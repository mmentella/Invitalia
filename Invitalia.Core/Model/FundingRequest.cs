using System;
using System.Collections.Generic;
using System.Linq;

namespace Invitalia.Core.Model
{
    public abstract class FundingRequest
        : Entity
    {
        private readonly List<OperatingUnit> operatingUnits;
        protected FundingRequest()
        {
            operatingUnits = new List<OperatingUnit>();
            CreatedUtc = DateTime.UtcNow;
        }

        public FundingRequest(string codiceMisura)
            : this()
        {
            FundingCode = codiceMisura;
        }

        public Applicant Proponente { get; set; }

        public string? RequestCode { get; set; }
        public string FundingCode { get; set; }
        public EntityType Type { get; set; }
        public OperatingUnit[] OperatingUnits
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

        public void SetCodiceDomanda(string codiceDomanda)
        {
            RequestCode = codiceDomanda;
            Modified();
        }

        public void SetProponente(Applicant proponente)
        {
            Proponente = proponente;
            proponente.Bind(this);
        }

        public void SetStato(EntityType stato)
        {
            Type = stato;
            stato.Bind(this);
        }

        public override void Bind(IEntity parent)
        {
            ParentId = "0";
        }
    }
}
