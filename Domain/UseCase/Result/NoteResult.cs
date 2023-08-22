namespace Domain.UseCase.Result
{
    public class NoteResult
    {
        private static NoteResult _success = new NoteResult { Succeeded = true };
        private readonly List<NoteError> _errors = new List<NoteError>();

        public bool Succeeded { get; protected set; }
        public static NoteResult Success => _success;
        public IEnumerable<NoteError> Errors => _errors;
        public static NoteResult Failed(params NoteError[] errors)
        {
            var result = new NoteResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }
    }
}
