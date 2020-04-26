using eDocument.ApplicationCore.Models;
using eDocument.Infrastructure.EmailSender.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eDocument.Infrastructure.Services
{
    public class UserManagerServers
    { 
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IEmailSender emailSender;
    

    public UserManagerServers(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.emailSender = emailSender;
    }
    public async Task ForgotPassword(ForgotPassword forgotPassword)
    {
        ForgotPasswordResult createdUserResult = new ForgotPasswordResult();
        var user = await userManager.FindByEmailAsync(forgotPassword.Email);
        if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
        {
            throw new ApplicationException($"Don't reveal that the user does not exist or is not confirmed '{forgotPassword.Email}'.");
        }
        var code = await userManager.GeneratePasswordResetTokenAsync(user);
        using (MailMessage mail = new MailMessage())
        {
            mail.To.Add(user.Email);
            mail.Subject = "Reset Password";
            mail.Body = "Please reset your password by clicking here: <a href=\"" + code + "\">link</a>";
            await emailService.SendAsync(mail);
        }
    }
    public async Task ChangePasswordUser(ChangePasswordUser changePasswordUser)
    {
        ChangePasswordUserResult result = new ChangePasswordUserResult();
        var user = await userManager.FindByEmailAsync(changePasswordUser.Email);

        if (user == null)
        {
            throw new ApplicationException($"Unable to load user with email '{changePasswordUser.Email}'.");
        }

        var changePasswordResult = await userManager.ChangePasswordAsync(user, changePasswordUser.OldPassword, changePasswordUser.NewPassword);
        if (!changePasswordResult.Succeeded)
        {
            throw new ApplicationException($"Unable to changePasswordResult user with email '{changePasswordUser.Email}'.");
        }
        await signInManager.SignInAsync(user, isPersistent: false);

        using (MailMessage mail = new MailMessage())
        {
            mail.To.Add(user.Email);
            mail.Subject = "Your password has been changed.";
            mail.Body = "User changed their password successfully.";
            await emailService.SendAsync(mail);
        }
    }
    public async Task<CreatedUserResult> CreatedUser(CreatedUser createdUser)
    {
        var userResult = await userManager.FindByEmailAsync(createdUser.Email);
        if (userResult != null)
        {
            throw new ApplicationException("jest taki user");
        }

        var user = new ApplicationUser { UserName = createdUser.Email, Email = createdUser.Email };

        var result = await userManager.CreateAsync(user, createdUser.Password);
        CreatedUserResult createdUserCommandResult = new CreatedUserResult();
        if (result.Succeeded)
        {
            IEnumerable<Claim> claims = new List<Claim>()
               {
                    new Claim(ClaimTypes.NameIdentifier, $"{user.Email}"),
                    new Claim(ClaimTypes.Email,  $"{user.Email}"),
                    new Claim(ClaimTypes.GivenName, $"{user.UserName}")
                };

            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret)),
            //    ValidIssuer = token.Issuer,
            //    ValidAudience = token.Audience,

            var resultClaims = await userManager.AddClaimsAsync(user, claims);

            if (!resultClaims.Succeeded)
                createdUserCommandResult.AddErros(resultClaims.Errors);
            await signInManager.SignInAsync(user, isPersistent: true);
            //createdUserCommandResult.Token = await userManager.GenerateUserTokenAsync(
            //user, "PasswordlessLoginTotpProvider", "passwordless-auth");
            //var testsss =   await userManager.//.GetAuthenticationTokenAsync(user, "Test", "access_token");
            createdUserCommandResult.Token = jwtTokenHandler.GenerateToken(user);
        }
        else
        {
            createdUserCommandResult.AddErros(result.Errors);
        }

        return createdUserCommandResult;
    }

    public async Task<bool> VerifyUserTokenAsync(string email, string token)
    {
        var userResult = await userManager.FindByEmailAsync(email);
        var isValid = await userManager.VerifyUserTokenAsync(
                  userResult, "PasswordlessLoginTotpProvider", "passwordless-auth", token);

        return isValid;
    }
}