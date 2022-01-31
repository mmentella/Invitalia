

using Invitalia.Infrastructures.Validators;

var corevalidator = new Invitalia.Core.Validators.OperatingUnitValidator();
var coreresult = corevalidator.Validate(new Invitalia.Core.Model.OperatingUnit());

var irvalidator = new OperatingUnitValidator();
var irresults = irvalidator.Validate(new Invitalia.Infrastructures.Model.OperatingUnit());

Console.ReadKey();