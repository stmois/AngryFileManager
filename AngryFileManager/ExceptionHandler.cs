using static AngryFileManager.FileManagerDelegates;

namespace AngryFileManager;

public static class ExceptionHandler
{
    public static void ShowUserException(
        string message, 
        AdditionalVoidWithoutParameter? additionalVoidWithoutParameter = null, 
        AdditionalVoidWithSingleBooleanParameter? additionalVoidWithParameter = null)
    {
        MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK);

        additionalVoidWithoutParameter?.Invoke();
        additionalVoidWithParameter?.Invoke(true);
    }
}