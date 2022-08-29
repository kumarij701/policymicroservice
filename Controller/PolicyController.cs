using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyAPI.Models;
using PolicyAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Roles = "User")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        private readonly log4net.ILog _log4net;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
            _log4net = log4net.LogManager.GetLogger(typeof(PolicyController));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetQuote")]
        public int GetQuote(int BusinessValue, int PropertyValue)
        {
            _log4net.Info("Getting quote value");
            var authtoken = this.Request.Headers["Authorization"][0];
            int quote = _policyService.GetQuote(BusinessValue, PropertyValue, authtoken);
            return quote;
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetPropertiesById")]
        public IActionResult GetProperties(int id)
        {
            _log4net.Info("Getting properties from Consumer API");
            var authtoken = this.Request.Headers["Authorization"][0];
            var properties = _policyService.GetPropertiesById(id, authtoken);
            return Ok(properties);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetBusinessById")]
        public IActionResult GetBusiness(int id)
        {
            _log4net.Info("Getting business values from Consumer API");
            var authtoken = this.Request.Headers["Authorization"][0];
            var business = _policyService.GetBusinessById(id, authtoken);
            return Ok(business);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CreatePolicy")]
        public async Task<string> CreatePolicy(int PropertyId)
        {
            _log4net.Info("Creating policy has been accessed");
            var authtoken = this.Request.Headers["Authorization"][0];
            return await _policyService.CreatePolicy(PropertyId, authtoken);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("IssuePolicy")]
        public async Task<string> IssuePolicy(int PolicyId, string PaymentDetails)
        {
            _log4net.Info("IssuePolicy has been accessed");
            return await _policyService.IssuePolicy(PolicyId, PaymentDetails);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("ViewConsumerPolicyById")]
        public virtual dynamic ViewConsumerPolicyById(int PolicyId)
        {
            _log4net.Info("ViewConsumerPolicyById has been accessed");
            var authtoken = this.Request.Headers["Authorization"][0];
            var policy = _policyService.ViewPolicyById(PolicyId, authtoken);
            return policy;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("ViewPoliciesById")]
        public dynamic GetPoliciesById(int id)
        {
            _log4net.Info("Getting Policies By Id");
            var policy = _policyService.GetPoliciesById(id);
            return policy;
        }


    }
}
