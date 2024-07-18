using System.Net;

namespace MobyLabWebProgramming.Core.Errors;

/// <summary>
/// Common error messages that may be reused in various places in the code.
/// </summary>
public static class CommonErrors
{
    public static ErrorMessage UserNotFound => new(HttpStatusCode.NotFound, "User doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage FileNotFound => new(HttpStatusCode.NotFound, "File not found on disk!", ErrorCodes.PhysicalFileNotFound);
    public static ErrorMessage TechnicalSupport => new(HttpStatusCode.InternalServerError, "An unknown error occurred, contact the technical support!", ErrorCodes.TechnicalError);
    public static ErrorMessage SolicitantNotFound => new(HttpStatusCode.NotFound, "Solicitant doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage DosarNotFound => new(HttpStatusCode.NotFound, "Dosar doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage StudiiNotFound => new(HttpStatusCode.NotFound, "Cod Studii doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage CorNotFound => new(HttpStatusCode.NotFound, " Cor doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage OlmNotFound => new(HttpStatusCode.NotFound, " Oferta Loc Munca  doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage RepartitieNotFound => new(HttpStatusCode.NotFound, " Repartitie  doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage CnpCalificariNotFound => new(HttpStatusCode.NotFound, " CnpCalificari  doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage CnpStudiiNotFound => new(HttpStatusCode.NotFound, " CnpStudii  doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage DosarRepartitiiNotFound => new(HttpStatusCode.NotFound, " DosarRepartitii  doesn't exist!", ErrorCodes.EntityNotFound);

}
