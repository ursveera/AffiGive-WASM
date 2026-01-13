using SharedLib.DTO;

namespace WASM.api
{
    public interface IAdminLottieApi
    {
        Task<List<LottieDto>> GetAll();
        Task<LottieDto?> GetById(int id);
        Task<bool> Add(LottieDto lottie);
        Task<bool> Update(LottieDto lottie);
        Task<bool> DeleteById(int id);
    }
}
