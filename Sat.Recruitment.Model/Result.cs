namespace Sat.Recruitment.Model
{
    public sealed class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }

        public Result(bool isSuccess, string errors)
        {
            SetResult(isSuccess, errors);
        }

        public Result SetResult(bool isSuccess, string errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;

            return this;
        }
    }
}
