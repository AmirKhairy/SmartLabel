using MediatR;
using SmartLabel.Application.Bases;
using SmartLabel.Application.Features.Authentication.Results;

namespace SmartLabel.Application.Features.Authentication.Command.Models;
public class SignInCommand : IRequest<Response<AuthResponse>>
{
	public string Email { get; set; }
	public string Password { get; set; }
}