using Lesson_11_RecruitmentApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

while (true)
{

 

    String RecordType = "Vacancy";
    String Status = "Создано";
    List<Record> records = new List<Record>();
    Record softwareEngineerVacancy = new Record("SoftwareEngineer0001", RecordType, Status);
    records.Add(softwareEngineerVacancy);
    Record frontEndEngineerVacancy = new Record("FrontEndEngineer0020", RecordType, Status);
    records.Add(frontEndEngineerVacancy);
    Record frontEndEngineerVacancy2 = new Record("FrontEndEngineer0021", RecordType, Status);
    records.Add(frontEndEngineerVacancy2);
    Record frontEndEngineerResume = new Record("FrontEndEngineer0044", "Resume", Status);
    records.Add(frontEndEngineerResume);

    foreach (Record record in records)
    {
        record.InvalidOperation += message => Console.WriteLine($"Ошибка проведения операции: {message}");
        record.ModifiedStatus += status => Console.WriteLine($"Новый статус записи: {status}");

    }   

    Console.WriteLine("Отдел кадров приветствует вас!");
  

        while (true)
        {
        Console.WriteLine("Список вакансий:");
        foreach (Record record in records)
        {
            record.ViewRecord();
        }
        Console.WriteLine($"Выберите операцию:");
            Console.WriteLine($"\t1.Отправить на рассмотрение");
            Console.WriteLine($"\t2.Утвердить");
            Console.WriteLine($"\t3.Отклонить");
            Console.WriteLine($"\t4.Назад");


            var command2 = Console.ReadLine();
            if (command2 == "1")
            {
                Console.WriteLine($"Введите id вакансии для отправки на рассмотрение");
                var idToBeSubmitForApproval = Console.ReadLine();
                foreach (Record record in records)
                {
                    if (idToBeSubmitForApproval == record.Id) 
                { 
                    record.SubmitForApproval();
                }
                }
            }
            else if
                 (command2 == "2")
            {
                Console.WriteLine($"Введите id вакансии для утверждения");
                var idToApprove = Console.ReadLine();
                foreach (Record record in records)
                {
                    if (idToApprove == record.Id)
                {
                    record.ApproveVacancy();
                }
                }
            }
            else if
                (command2 == "3")
            {
                Console.WriteLine($"Введите id вакансии для отклонения");
                var idToReject = Console.ReadLine();
                foreach (Record record in records)
                {
                    if (idToReject == record.Id)
                { 
                    record.RejectVacancy(); 
                }
                }
            }
            else if
                (command2 == "4")
            {
                Console.WriteLine($"Всего хорошего!");
            Process.GetCurrentProcess().Kill();
                

            }
           
        }
    }





/**
* TODO: Разработать сервис и вызвать действия так как указано:
*/

// Вызвать действие "Submit For Approval" для softwareEngineerVacancy (Отправить на утверждение)
// Вызвать действие "Approve" для softwareEngineerVacancy (Утвердить)

// Вызвать действие "Submit For Approval" для frontEndEngineerVacancy
// Вызвать действие "Reject" для frontEndEngineerVacancy (Отклонить)

/**
    //TODO: Разработать сервис

    public class <Service> {

    }

*/
