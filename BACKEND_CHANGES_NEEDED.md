# Backend Changes Required for Delete Participant Feature

The following changes need to be made in the **AffiGive_API_V1** project:

## 1. Add to Repository Interface
**File:** `Repos/Rewards/IGiftParticipationRepository.cs`

```csharp
public interface IGiftParticipationRepository
{
    Task<List<GiftParticipation>> GetByGiftIdAsync(int giftId);
    Task<List<GiftParticipation>> GetAllAsync();
    Task<bool> DeleteParticipantAsync(int giftId, string userId);
    // ... other methods
}
```

## 2. Implement in Repository Class
**File:** `Repos/Rewards/GiftParticipationRepository.cs`

```csharp
public async Task<bool> DeleteParticipantAsync(int giftId, string userId)
{
    try
    {
        var participant = await _context.GiftParticipations
            .FirstOrDefaultAsync(gp => gp.GiftId == giftId && gp.UserId == userId);

        if (participant == null)
            return false;

        _context.GiftParticipations.Remove(participant);
        await _context.SaveChangesAsync();
        return true;
    }
    catch
    {
        return false;
    }
}
```

## 3. Add to Service Interface
**File:** `Services/IGiftParticipationService.cs` (or similar)

```csharp
public interface IGiftParticipationService
{
    Task<List<GiftParticipation>> GetByGiftIdAsync(int giftId);
    Task<List<GiftParticipation>> GetAllAsync();
    Task<bool> DeleteParticipantAsync(int giftId, string userId);
    // ... other methods
}
```

## 4. Implement in Service Class
**File:** `Services/GiftParticipationService.cs` (or similar)

```csharp
public async Task<bool> DeleteParticipantAsync(int giftId, string userId)
{
    return await _repository.DeleteParticipantAsync(giftId, userId);
}
```

## 5. Add Endpoint to Controller
**File:** `Controllers/GiftController.cs`

```csharp
[HttpDelete("{giftId}/participants/{userId}")]
public async Task<IActionResult> DeleteParticipant(int giftId, string userId)
{
    var result = await _service.DeleteParticipantAsync(giftId, userId);
    if (!result)
        return NotFound("Participant not found");

    return Ok(new { message = "Participant deleted successfully" });
}
```

## Summary
- ✅ Repository Interface: Add method signature
- ✅ Repository Implementation: Add delete logic
- ✅ Service Interface: Add method signature
- ✅ Service Implementation: Add service logic
- ✅ Controller: Add DELETE endpoint at `DELETE /Gift/{giftId}/participants/{userId}`

The frontend is already configured to call this endpoint!
