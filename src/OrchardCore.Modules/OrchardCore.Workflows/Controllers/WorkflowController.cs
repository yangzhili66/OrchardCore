using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrchardCore.Workflows.Services;

namespace OrchardCore.Workflows.Controllers
{
    public class WorkflowController : Controller
    {
        private readonly IWorkflowManager _workflowManager;
        private readonly IWorkflowDefinitionRepository _workflowDefinitionRepository;
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController(IWorkflowManager workflowManager, IWorkflowDefinitionRepository workflowDefinitionRepository, ILogger<WorkflowController> logger)
        {
            _workflowManager = workflowManager;
            _workflowDefinitionRepository = workflowDefinitionRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Invoke(int workflowDefinitionId)
        {
            var workflowDefinition = await _workflowDefinitionRepository.GetWorkflowDefinitionAsync(workflowDefinitionId);
            var workflowContext = await _workflowManager.StartWorkflowAsync(workflowDefinition);

            var test = Response.StatusCode;
            return Ok();
        }
    }
}
