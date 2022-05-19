using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_RecruitmentApp
{
    public class Record
    {
        public string Id { get; private set; }
        public string Type { get; private set; }
        public string Status { get; private set; }
        // private Record _record;

        public Record(string id, string type, string status)
        {
            Id = id;
            Type = type;
            Status = status;

        }
        public event Action<string> InvalidOperation;
        public event Action<string> ModifiedStatus;

        //public event Action<string> SubmittingForApproval;
        //public event Action<string> ApprovingVacancy;
        //public event Action<string> RejectingVacancy;

        public void ViewRecord()
        {
            if (Type == "Vacancy")
            {
                Console.WriteLine($"Вакансия:{Id} Статус:{Status}");

            };

        }

        public void SubmitForApproval()
        {
            Status = "Отправлено на рассмотрение";

            ModifiedStatus?.Invoke(Status);
        }

        public void ApproveVacancy()
        {
            if (Status == "Отправлено на рассмотрение")
            {
                Status = "Утверждено";
                ModifiedStatus?.Invoke(Status);
            }
            else InvalidOperation?.Invoke("Нельзя утвердить неотправленную на рассмотрение запись.");
        }

        public void RejectVacancy()
        {
            if (Status == "Отправлено на рассмотрение")
            {
                Status = "Отказано";
                ModifiedStatus?.Invoke(Status);
            }
            else InvalidOperation?.Invoke("Нельзя отклонить неотправленную на рассмотрение запись.");
        }

    }
}

