using Lesson_11_RecruitmentApp;
using System;

Console.WriteLine("Отдел кадров приветствует вас!");

String RecordType = "Vacancy";

Record softwareEngineerVacancy = new Record("SoftwareEngineer0001", RecordType);
Record frontEndEngineerVacancy = new Record("FrontEndEngineer0020", RecordType);

/**
* TODO: Разработать сервис и вызвать действия так как указано:
*/

// Вызвать действие "Submit For Approval" для softwareEngineerVacancy
// Вызвать действие "Approve" для softwareEngineerVacancy

// Вызвать действие "Submit For Approval" для frontEndEngineerVacancy
// Вызвать действие "Reject" для frontEndEngineerVacancy

/**
    //TODO: Разработать сервис

    public class <Service> {

    }
*/
Service service = new Service();

Console.WriteLine("1. " + softwareEngineerVacancy.Id + "\n" +"2. " + frontEndEngineerVacancy.Id);

int number_of_cv = Convert.ToInt32(Console.ReadLine());

string curent_cv = "";

if (number_of_cv == 1)
{
    curent_cv += softwareEngineerVacancy.Id;
    string service_submit = service.Submit + curent_cv;
    Console.WriteLine(service_submit);
}

else if (number_of_cv == 2)
{
    curent_cv += frontEndEngineerVacancy.Id;
    string service_submit = service.Submit + curent_cv;
    Console.WriteLine(service_submit);
}

else
{
    throw new Exception();
}



Console.WriteLine("1. Approve \n2. Reject.");

int number_of_operation = Convert.ToInt32(Console.ReadLine());
if(number_of_operation == 1)
{
    string service_approve = service.Approve + curent_cv;
    Console.WriteLine(service_approve);
}
else if (number_of_operation == 2)
{
    string service_reject = service.Reject + curent_cv;
    Console.WriteLine(service_reject);
}
else
{
    throw new Exception();
}


public class Service
{
    private string submit_text = "Отправлено на рассмотрение: ";

    public string Submit
    {
        get
        {
            return submit_text;
        }
        set
        {
            submit_text = value;
        }
    }

    private string approve_text = "Утверждено: ";

    public string Approve
    {
        get
        {
            return approve_text;
        }
        set
        {
            approve_text = value;
        }
    }

    private string reject_text = "Отказ: ";

    public string Reject
    {
        get
        {
            return reject_text;
        }
        set
        {
            reject_text = value;
        }
    }
}