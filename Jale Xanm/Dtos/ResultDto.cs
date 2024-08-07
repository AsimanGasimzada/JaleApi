
namespace Jale_Xanm.Dtos;

public class ResultDto : IResult
{

    public int StatusCode { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }


    public ResultDto(int statusCode,bool isSuccess,string message)
    {
        StatusCode = statusCode;
        Message = message;
        IsSuccess = isSuccess;
    }
    public Task ExecuteAsync(HttpContext httpContext)
    {
        throw new NotImplementedException();
    }
}
