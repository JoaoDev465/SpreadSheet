using System.Web;
using Core.Entities;
using QuestPDF.Fluent;

namespace Core.Interface;

public interface IPdfServices
{
   abstract Task< Byte[]> Pdf();
}