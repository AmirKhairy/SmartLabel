﻿using FluentValidation;
using SmartLabel.Application.Features.Banners.Command.Models;

namespace SmartLabel.Application.Features.Banners.Command.Validators;
public class AddBannerValidator : AbstractValidator<AddBannerCommand>
{

	public AddBannerValidator()
	{
		ApplyValidationRules();
		AddCustomValidationRules();
	}
	private void ApplyValidationRules()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("{PropertyName} must be not empty")
			.MaximumLength(1000).WithMessage("{PropertyName} cannot exceed 1000 characters.");
		RuleFor(x => x.Description)
			.MaximumLength(2000).WithMessage("{PropertyName} cannot exceed 2000 characters.");
		RuleFor(x => x.MainImage)
			.NotEmpty().WithMessage("You should upload at least one Image");
	}
	private void AddCustomValidationRules()
	{
		RuleFor(x => x.StartDate)
			.Must(startDate => startDate != default)
			.WithMessage("{PropertyName} is not valid date time");
		RuleFor(x => x.EndDate)
			.Must(endDate => endDate != default)
			.WithMessage("{PropertyName} is not valid date time");
		RuleFor(x => x.StartDate)
			.Must((bannerRequest, startDate) => bannerRequest.EndDate > startDate)
			.WithMessage("EndDate should be greater than startDate");
	}
}