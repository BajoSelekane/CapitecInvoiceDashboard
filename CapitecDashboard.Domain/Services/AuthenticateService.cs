using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Interfaces.Services.CommandService;
using CapitecDashboard.Domain.Models;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Utils;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ILogger<AuthenticateService> logger;
        private readonly IConfiguration configuration;
        private readonly UserStore<User> userStore;
       // private readonly IUserFacilityCommandService userFacilityCommandService;
        //private readonly IQueryRepository<UserFacility, UserFacilityFilter> userFacilityQueryRepository;
        private readonly IEmailService emailService;
        private readonly IUserDetailCommandService userDetailCommandService;
        private readonly IQueryRepository<UserDetail, UserDetailFilter> userDetailQueryRepository;


        // private readonly UserStore<User> userStore;

        public AuthenticateService(UserManager<User> userManager, IQueryRepository<UserFacility, UserFacilityFilter> userFacilityQueryRepository,
            IConfiguration configuration, SignInManager<User> signInManager,
            ILogger<AuthenticateService> logger, UserStore<User> userStore, RoleManager<Role> roleManager,
            IUserFacilityCommandService userFacilityCommandService,
            IEmailService emailService, IQueryRepository<UserDetail, UserDetailFilter> userDetailQueryRepository,
            IUserDetailCommandService userDetailCommandService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
            this.configuration = configuration;
            this.userStore = userStore;
            this.roleManager = roleManager;
            //this.userFacilityCommandService = userFacilityCommandService;
            //this.userFacilityQueryRepository = userFacilityQueryRepository;
            this.emailService = emailService;
            this.userDetailQueryRepository = userDetailQueryRepository;
            this.userDetailCommandService = userDetailCommandService;
        }

        public async Task<ObjectResponse<UserResponse>> Login(LoginRequest request)
        {
            ObjectResponse<UserResponse> response = new ObjectResponse<UserResponse>();

            try
            {
                var userExists = userManager.Users.FirstOrDefault(x => x.PhoneNumber == request.Username || x.Email == request.Username);

                if (userExists == null)
                {
                    response.CodeStatus = ResponseStatus.Fail;
                    response.Message = "Username and password does not match, please provide correct details.";
                    return response;

                }
                var result = await signInManager
                    .PasswordSignInAsync(userExists.UserName, request.Password, false, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    response.CodeStatus = ResponseStatus.Fail;
                    response.Message = "Username and password does not match, please provide correct details.";
                    return response;
                }

                var user = await userManager.FindByNameAsync(userExists.UserName);

                var roles = await userManager.GetRolesAsync(user);


                var data = new UserResponse
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles,
                    UserTypeId = user.ImplementationType,
                    UserType = user.ImplementationType.ToString(),

                };

                response.Data = data;
                response.CodeStatus = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.CodeStatus = ResponseStatus.Fail;
                response.Message = "An exception has occured trying to sign in user.";
                logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> CreateNewRole(RoleRequest request)
        {
            var response = new BaseResponse();

            var isRoleExist = await roleManager.RoleExistsAsync(request.Name.Trim());

            if (!isRoleExist)
            {
                var res = await roleManager.CreateAsync(new Role(request.Name, request.ProgramDataId, request.AccessLevelId));

                if (!res.Succeeded)
                {
                    return new BaseResponse
                    {
                        CodeStatus = ResponseStatus.Fail,
                        Message = "Failed to create role, please try again later."
                    };
                }

                response.CodeStatus = ResponseStatus.Success;
            }
            else
            {
                response.CodeStatus = ResponseStatus.Fail;
                response.Message = "This role already exist.";

            }

            return response;
        }

        public ObjectListResponse<UserResponse> Filter(UserFilter filter)
        {
            var response = new ObjectListResponse<UserResponse>();

            var userRes = new List<UserResponse>();

            var res = userManager.Users.ToList();

            foreach (var user in res)
            {

                userRes.Add(
                    new UserResponse
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        UserTypeId = user.ImplementationType
                    });
            }
            response.Data = userRes;
            response.CodeStatus = Enums.ResponseStatus.Success;

            return response;
        }

        public ObjectResponse<UserResponse> GetUserById(string userId)
        {
            var response = new ObjectResponse<UserResponse>();

            var user = userManager.Users.FirstOrDefault(x => x.Id == userId);


            var userRes = new UserResponse
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserTypeId = user.ImplementationType
            };

            response.Data = userRes;
            response.CodeStatus = Enums.ResponseStatus.Success;

            return response;
        }



        public async Task<ObjectResponse<UserResponse>> Register(UserRequest request)
        {
            ObjectResponse<UserResponse> response = new ObjectResponse<UserResponse>();

            string provinceId = null;
            string districtId = null;
            string subDistrictId = null;
            string facilityId = null;
            string operationId = null;

            try
            {

                var checkUserResults = await userManager.FindByEmailAsync(request.Email);

                if (checkUserResults != null)
                {
                    response.Message = $"User by this email '{request.Email}' already exist.";
                    response.CodeStatus = Enums.ResponseStatus.Fail;
                    return response;
                }

                var user = new User
                {
                    FirstName = request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                    UserName = request.Email.Trim(),
                    PhoneNumber = string.IsNullOrWhiteSpace(request.Phone) ? "" : request.Phone.Trim(),
                    Email = request.Email.Trim(),
                    EmailConfirmed = true,
                    ImplementationType = request.ImplementationType
                };

                //var results = await userManager.CreateAsync(user, request.Password
                var results = await userManager.CreateAsync(user, "Password@2023");


                if (!results.Succeeded)
                {

                    string message = "Failed to create user, please try again.";

                    if (results.Errors != null && results.Errors.Any())
                    {
                        StringBuilder stringBuilder = new StringBuilder();

                        foreach (var error in results.Errors)
                        {
                            stringBuilder.AppendLine(error.Description);
                        }

                        message = stringBuilder.ToString();
                    }


                    response.Message = message;
                    response.CodeStatus = ResponseStatus.Fail;
                    return response;
                }

                var roles = roleManager.Roles.ToList();

                if (string.IsNullOrEmpty(request.RoleId))
                {
                    var role = roles
                        .FirstOrDefault(
                        x => x.Name.Contains("Data",
                        StringComparison.InvariantCultureIgnoreCase));

                    var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    var role = roles.FirstOrDefault(x => x.Id == request.RoleId);
                    var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                }


                //if (request.FacilityId != null)
                //{
                //    UserFacilityRequest userFacilityRequest = new UserFacilityRequest
                //    {
                //        UserId = user.Id,
                //        Id = Guid.NewGuid().ToString(),
                //        FacilityId = request.FacilityId,
                //        FacilityUserId = user.Id
                //    };

                //    userFacilityCommandService.Add(userFacilityRequest);
                //}

                //if (request.ProvinceId != null)
                //{
                //    provinceId = request.ProvinceId;
                //}

                //if (request.DistrictId != null)
                //{
                //    districtId = request.DistrictId;
                //}

                //if (request.SubDistrictId != null)
                //{
                //    subDistrictId = request.SubDistrictId;
                //}

                //if (request.FacilityId != null)
                //{
                //    facilityId = request.FacilityId;
                //}

                //if (request.OperationId != null)
                //{
                //    operationId = request.OperationId;
                //}
                //else
                //{
                //    operationId = null;
                //}



                if (request.FirstName != null)
                {
                    UserDetailRequest userDetailRequest = new UserDetailRequest
                    {
                        UserId = user.Id,
                        Id = Guid.NewGuid().ToString(),
                        ProvinceId = provinceId,
                        DistrictId = districtId,
                        SubDistrictId = subDistrictId,
                        FacilityId = facilityId,
                        OperationId = operationId,
                        UserDetailId = user.Id
                    };

                    userDetailCommandService.Add(userDetailRequest);
                }


                response.CodeStatus = ResponseStatus.Success;
                response.Message = "You have been registered successfully.";

                SendEmail(
                    request.Email.Trim(),
                    string.Format("{0} {1}",
                    request.FirstName,
                    request.LastName),
                    "Password@2023");

            }
            catch (Exception ex)
            {
                response.CodeStatus = ResponseStatus.Fail;
                response.Message = "An exception has occured trying to register user, please try again later.";
                logger.LogError(ex.Message);
            }

            return response;
        }

        //public async Task<BaseResponse> RemoveUserRole(RoleDeleteRequest request)
        //{
        //    var response = new ObjectResponse<UserResponse>();


        //    var role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == request.RoleId);
        //    var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);

        //    if (role == null)
        //    {
        //        response.Message = "Failed to remove this role from this user.";
        //        response.CodeStatus = ResponseStatus.Fail;

        //        return response;
        //    }

        //    var res = await userManager.RemoveFromRoleAsync(user, role.Name);

        //    if (!res.Succeeded)
        //    {
        //        response.Message = "Failed to remove this role from this user.";
        //        response.CodeStatus = ResponseStatus.Fail;
        //    }

        //    //response.Data = userRes;
        //    response.CodeStatus = Enums.ResponseStatus.Success;

        //    return response;
        //}

        //public async Task<BaseResponse> AddUserToRole(RoleAddRequest request)
        //{
        //    var response = new ObjectResponse<UserResponse>();


        //    var role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == request.RoleId);
        //    var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);

        //    var res = await userManager.AddToRoleAsync(user, role.Name);

        //    if (!res.Succeeded)
        //    {
        //        response.Message = "Failed to add this role to the user.";
        //        response.CodeStatus = ResponseStatus.Fail;
        //    }

        //    //response.Data = userRes;
        //    response.CodeStatus = Enums.ResponseStatus.Success;

        //    return response;
        //}

        //public async Task<ObjectResponse<UserResponse>> Update(UserRequest request)
        //{
        //    ObjectResponse<UserResponse> response = new ObjectResponse<UserResponse>();

        //    string provinceId = null;
        //    string districtId = null;
        //    string subDistrictId = null;
        //    string facilityId = null;
        //    string operationId = null;

        //    try
        //    {
        //        var user = await userManager
        //            .Users
        //            .Include(x => x.UserRoles)
        //            .ThenInclude(x => x.Role)
        //            .FirstOrDefaultAsync(x => x.Id == request.Id);

        //        if (user == null)
        //        {
        //            response.Message = "User was not found";
        //            response.CodeStatus = ResponseStatus.Fail;

        //            return response;
        //        }

        //        user.FirstName = request.FirstName.Trim();
        //        user.LastName = request.LastName.Trim();
        //        user.UserName = request.Email.Trim();
        //        user.PhoneNumber = request.Phone.Trim();
        //        user.Email = request.Email.Trim();
        //        user.EmailConfirmed = true;


        //        var updateRes = await userManager.UpdateAsync(user);

        //        if (!updateRes.Succeeded)
        //        {
        //            string message = "Failed to create user, please try again.";

        //            if (updateRes.Errors != null && updateRes.Errors.Any())
        //            {
        //                StringBuilder stringBuilder = new StringBuilder();

        //                foreach (var error in updateRes.Errors)
        //                {
        //                    stringBuilder.AppendLine(error.Description);
        //                }

        //                message = stringBuilder.ToString();
        //            }

        //            response.Message = message;
        //            response.CodeStatus = ResponseStatus.Fail;
        //            return response;
        //        }

        //        var roles = roleManager.Roles.ToList();

        //        if (request.Roles != null && request.Roles.Count() > 0)
        //        {
        //            foreach (var roleId in request.Roles)
        //            {
        //                var role = roles.FirstOrDefault(x => x.Id == roleId);
        //                var addRoleResult = await userManager.AddToRoleAsync(user, role.Id);
        //            }
        //        }

        //        if (request.ProvinceId != null)
        //        {
        //            provinceId = request.ProvinceId;
        //        }

        //        if (request.DistrictId != null)
        //        {
        //            districtId = request.DistrictId;
        //        }

        //        if (request.SubDistrictId != null)
        //        {
        //            subDistrictId = request.SubDistrictId;
        //        }

        //        if (request.FacilityId != null)
        //        {
        //            facilityId = request.FacilityId;
        //        }

        //        if (request.OperationId != null)
        //        {
        //            operationId = request.OperationId;
        //        }
        //        else
        //        {
        //            operationId = null;
        //        }

        //        var userData = userDetailQueryRepository.GetAll().Where(x => x.UserId == user.Id).ToList();
        //        if (userData != null)
        //        {
        //            var xUser = new UserDetailRequest
        //            {
        //                UserId = user.Id,
        //                Id = userData[0].Id,
        //                ProvinceId = provinceId,
        //                DistrictId = districtId,
        //                SubDistrictId = subDistrictId,
        //                FacilityId = facilityId,
        //                OperationId = operationId,
        //                UserDetailId = user.Id
        //            };

        //            userDetailCommandService.Edit(xUser);
        //        }


        //        response.CodeStatus = ResponseStatus.Success;
        //        response.Message = "You have been updated successfully.";

        //    }
        //    catch (Exception ex)
        //    {
        //        response.CodeStatus = ResponseStatus.Fail;
        //        response.Message = "An exception has occured trying to register user, please try again later.";
        //        logger.LogError(ex.Message);
        //    }

        //    return response;
        //}

        //public BaseResponse AssignUserToFacility(UserFacilityRequest request)
        //{
        //    var baseResponse = new BaseResponse();

        //    try
        //    {
        //        var userFacility = userFacilityQueryRepository
        //            .GetAll()
        //            .FirstOrDefault(x => x.FacilityId == request.FacilityId && x.UserId == request.FacilityUserId);

        //        if (userFacility != null)
        //        {
        //            return new BaseResponse
        //            {
        //                CodeStatus = ResponseStatus.Fail,
        //                Message = "This facility has already assigned to this user."
        //            };
        //        }

        //        userFacility = UserFacility.Create(request);
        //        baseResponse = userFacilityCommandService.Create(userFacility);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex.Message);
        //    }


        //    return baseResponse;
        //}

        //public BaseResponse SaveUserDetail(UserDetailRequest request)
        //{
        //    var baseResponse = new BaseResponse();

        //    try
        //    {
        //        var userDetail = userDetailQueryRepository
        //            .GetAll()
        //            .FirstOrDefault(x => x.UserId == request.UserDetailId);

        //        if (userDetail != null)
        //        {
        //            return new BaseResponse
        //            {
        //                CodeStatus = ResponseStatus.Fail,
        //                Message = "This detail has already assigned to this user."
        //            };
        //        }

        //        userDetail = UserDetail.Create(request);
        //        baseResponse = userDetailCommandService.Create(userDetail);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex.Message);
        //    }


        //    return baseResponse;
        //}

        private void SendEmail(string emailAddress, string name, string password)
        {
            var to = new Dictionary<string, string>();
            to.Add(emailAddress, emailAddress);

            var callbackUrl = configuration.GetValue<string>("SystemConfig:URL");

            string systemName = configuration.GetValue<string>("SystemConfig:Name");

            var email = Email.Create(to, null, "Registered Successful",
                $"Hi {name} you've been registered on {systemName}, you can follow this " +
                $"<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>link</a> to login to the system. <br> <br>Here are your credentials username: {emailAddress} and password: {password}<br> <br>");
            this.emailService.Send(email);
        }
    }
}
