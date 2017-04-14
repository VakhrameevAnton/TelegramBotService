using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Jira;
using JiraBridge.Classes;

namespace JiraBridge
{
    public class JiraBridge: IJiraBridge
    {
        private readonly string _host;
        private readonly string _service;
        private readonly string _user;
        private readonly string _password;
        private readonly string _project;
        private readonly string _priority;

        private bool _authenticated = false;

        private Jira _jira;

        public JiraBridge(JiraSetupContract setupInfo)
        {
            _host = setupInfo.JiraHost;
            _service = setupInfo.JiraService;
            _user = setupInfo.JiraUser;
            _password = setupInfo.JiraPassword;
            _project = setupInfo.JiraProject;
            _priority = setupInfo.JiraPriority;
        }

        public void Authenticate()
        {
            if (_authenticated) return;

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            _jira = Jira.CreateRestClient($"{_host}/{_service}", _user, _password);

            _authenticated = true;
        }

        public string CreateTaskIssue(CreateJiraTaskContract contract)
        {
            var key = string.Empty;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                Authenticate();

                var issue = _jira.CreateIssue(_project);

                if (issue == null)
                    throw new ApplicationException("Не удалось создать задачу в jira");

                issue.Type = "Ошибка";
                issue.Priority = string.IsNullOrEmpty(_priority) ? "Важный" : _priority;

                issue.Summary = $"Тестовая заявка";

                var nl = Environment.NewLine;

                var body = new StringBuilder($"Текст заявки");

                issue.Description = body.ToString();

                issue.SaveChanges();

                //foreach (var file in contract.Attachments)
                //    issue.AddAttachment(file.Key, file.Value);

                if (issue.Key != null)
                    key = issue.Key.Value;

                return key;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
