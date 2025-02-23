using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDLAPI
{
    public static SDL_GPUCommandBuffer* AcquireGpuCommandBuffer(SDL_GPUDevice* device) => SDL_AcquireGPUCommandBuffer(device);

    public static bool AcquireGpuSwapchainTexture(SDL_GPUCommandBuffer* commandBuffer, SDL_Window* window, SDL_GPUTexture** swapchainTexture, uint* swapchainTextureWidth, uint* swapchainTextureHeight) =>
        SDL_AcquireGPUSwapchainTexture(commandBuffer, window, swapchainTexture, swapchainTextureWidth, swapchainTextureHeight);

    public static SDL_GPUComputePass* BeginGpuComputePass(SDL_GPUCommandBuffer* commandBuffer, SDL_GPUStorageTextureReadWriteBinding* storageTextureBindings, uint numStorageTextureBindings,
        SDL_GPUStorageBufferReadWriteBinding* storageBufferBindings, uint numStorageBufferBindings) =>
        SDL_BeginGPUComputePass(commandBuffer, storageTextureBindings, numStorageTextureBindings, storageBufferBindings, numStorageBufferBindings);

    public static SDL_GPUCopyPass* BeginGpuCopyPass(SDL_GPUCommandBuffer* commandBuffer) => SDL_BeginGPUCopyPass(commandBuffer);

    public static SDL_GPURenderPass* BeginGpuRenderPass(SDL_GPUCommandBuffer* commandBuffer, SDL_GPUColorTargetInfo* colorTargetInfos, uint numColorTargets, SDL_GPUDepthStencilTargetInfo* depthStencilTargetInfo) =>
        SDL_BeginGPURenderPass(commandBuffer, colorTargetInfos, numColorTargets, depthStencilTargetInfo);

    public static void BindGpuComputePipeline(SDL_GPUComputePass* computePass, SDL_GPUComputePipeline* computePipeline) => SDL_BindGPUComputePipeline(computePass, computePipeline);

    public static void BindGpuComputeSamplers(SDL_GPUComputePass* computePass, uint firstSlot, SDL_GPUTextureSamplerBinding* textureSamplerBindings, uint numBindings) =>
        SDL_BindGPUComputeSamplers(computePass, firstSlot, textureSamplerBindings, numBindings);

    public static void BindGpuComputeStorageBuffers(SDL_GPUComputePass* computePass, uint firstSlot, SDL_GPUBuffer** storageBuffers, uint numBindings) =>
        SDL_BindGPUComputeStorageBuffers(computePass, firstSlot, storageBuffers, numBindings);

    public static void BindGpuComputeStorageTextures(SDL_GPUComputePass* computePass, uint firstSlot, SDL_GPUTexture** storageTextures, uint numBindings) =>
        SDL_BindGPUComputeStorageTextures(computePass, firstSlot, storageTextures, numBindings);

    public static void BindGpuFragmentSamplers(SDL_GPURenderPass* renderPass, uint firstSlot, SDL_GPUTextureSamplerBinding* textureSamplerBindings, uint numBindings) =>
        SDL_BindGPUFragmentSamplers(renderPass, firstSlot, textureSamplerBindings, numBindings);

    public static void BindGpuFragmentStorageBuffers(SDL_GPURenderPass* renderPass, uint firstSlot, SDL_GPUBuffer** storageBuffers, uint numBindings) =>
        SDL_BindGPUFragmentStorageBuffers(renderPass, firstSlot, storageBuffers, numBindings);

    public static void BindGpuFragmentStorageTextures(SDL_GPURenderPass* renderPass, uint firstSlot, SDL_GPUTexture** storageTextures, uint numBindings) =>
        SDL_BindGPUFragmentStorageTextures(renderPass, firstSlot, storageTextures, numBindings);

    public static void BindGpuGraphicsPipeline(SDL_GPURenderPass* renderPass, SDL_GPUGraphicsPipeline* graphicsPipeline) => SDL_BindGPUGraphicsPipeline(renderPass, graphicsPipeline);
    public static void BindGpuIndexBuffer(SDL_GPURenderPass* renderPass, SDL_GPUBufferBinding* binding, SDL_GPUIndexElementSize indexElementSize) => SDL_BindGPUIndexBuffer(renderPass, binding, indexElementSize);
    public static void BindGpuVertexBuffers(SDL_GPURenderPass* renderPass, uint firstSlot, SDL_GPUBufferBinding* bindings, uint numBindings) => SDL_BindGPUVertexBuffers(renderPass, firstSlot, bindings, numBindings);

    public static void BindGpuVertexSamplers(SDL_GPURenderPass* renderPass, uint firstSlot, SDL_GPUTextureSamplerBinding* textureSamplerBindings, uint numBindings) =>
        SDL_BindGPUVertexSamplers(renderPass, firstSlot, textureSamplerBindings, numBindings);

    public static void BindGpuVertexStorageBuffers(SDL_GPURenderPass* renderPass, uint firstSlot, SDL_GPUBuffer** storageBuffers, uint numBindings) =>
        SDL_BindGPUVertexStorageBuffers(renderPass, firstSlot, storageBuffers, numBindings);

    public static void BindGpuVertexStorageTextures(SDL_GPURenderPass* renderPass, uint firstSlot, SDL_GPUTexture** storageTextures, uint numBindings) =>
        SDL_BindGPUVertexStorageTextures(renderPass, firstSlot, storageTextures, numBindings);

    public static void BlitGpuTexture(SDL_GPUCommandBuffer* commandBuffer, SDL_GPUBlitInfo* info) => SDL_BlitGPUTexture(commandBuffer, info);
    public static uint CalculateGpuTextureFormatSize(SDL_GPUTextureFormat format, uint width, uint height, uint depthOrLayerCount) => SDL_CalculateGPUTextureFormatSize(format, width, height, depthOrLayerCount);
    public static bool CancelGpuCommandBuffer(SDL_GPUCommandBuffer* commandBuffer) => SDL_CancelGPUCommandBuffer(commandBuffer);
    public static bool ClaimWindowForGpuDevice(SDL_GPUDevice* device, SDL_Window* window) => SDL_ClaimWindowForGPUDevice(device, window);

    public static void CopyGpuBufferToBuffer(SDL_GPUCopyPass* copyPass, SDL_GPUBufferLocation* source, SDL_GPUBufferLocation* destination, uint size, bool cycle) =>
        SDL_CopyGPUBufferToBuffer(copyPass, source, destination, size, cycle);

    public static void CopyGpuTextureToTexture(SDL_GPUCopyPass* copyPass, SDL_GPUTextureLocation* source, SDL_GPUTextureLocation* destination, uint w, uint h, uint d, bool cycle) =>
        SDL_CopyGPUTextureToTexture(copyPass, source, destination, w, h, d, cycle);

    public static SDL_GPUBuffer* CreateGpuBuffer(SDL_GPUDevice* device, SDL_GPUBufferCreateInfo* createinfo) => SDL_CreateGPUBuffer(device, createinfo);
    public static SDL_GPUComputePipeline* CreateGpuComputePipeline(SDL_GPUDevice* device, SDL_GPUComputePipelineCreateInfo* createinfo) => SDL_CreateGPUComputePipeline(device, createinfo);
    public static SDL_GPUDevice* CreateGpuDevice(SDL_GPUShaderFormat formatFlags, bool debugMode, byte* name) => SDL_CreateGPUDevice(formatFlags, debugMode, name);
    public static SDL_GPUDevice* CreateGpuDevice(SDL_GPUShaderFormat formatFlags, bool debugMode, string name) => SDL_CreateGPUDevice(formatFlags, debugMode, name);
    public static SDL_GPUDevice* CreateGpuDeviceWithProperties(SDL_PropertiesID props) => SDL_CreateGPUDeviceWithProperties(props);
    public static SDL_GPUGraphicsPipeline* CreateGpuGraphicsPipeline(SDL_GPUDevice* device, SDL_GPUGraphicsPipelineCreateInfo* createinfo) => SDL_CreateGPUGraphicsPipeline(device, createinfo);
    public static SDL_GPUSampler* CreateGpuSampler(SDL_GPUDevice* device, SDL_GPUSamplerCreateInfo* createinfo) => SDL_CreateGPUSampler(device, createinfo);
    public static SDL_GPUShader* CreateGpuShader(SDL_GPUDevice* device, SDL_GPUShaderCreateInfo* createinfo) => SDL_CreateGPUShader(device, createinfo);
    public static SDL_GPUTexture* CreateGpuTexture(SDL_GPUDevice* device, SDL_GPUTextureCreateInfo* createinfo) => SDL_CreateGPUTexture(device, createinfo);
    public static SDL_GPUTransferBuffer* CreateGpuTransferBuffer(SDL_GPUDevice* device, SDL_GPUTransferBufferCreateInfo* createinfo) => SDL_CreateGPUTransferBuffer(device, createinfo);
    public static void DestroyGpuDevice(SDL_GPUDevice* device) => SDL_DestroyGPUDevice(device);
    public static void DispatchGpuCompute(SDL_GPUComputePass* computePass, uint groupcountX, uint groupcountY, uint groupcountZ) => SDL_DispatchGPUCompute(computePass, groupcountX, groupcountY, groupcountZ);
    public static void DispatchGpuComputeIndirect(SDL_GPUComputePass* computePass, SDL_GPUBuffer* buffer, uint offset) => SDL_DispatchGPUComputeIndirect(computePass, buffer, offset);
    public static void DownloadFromGpuBuffer(SDL_GPUCopyPass* copyPass, SDL_GPUBufferRegion* source, SDL_GPUTransferBufferLocation* destination) => SDL_DownloadFromGPUBuffer(copyPass, source, destination);
    public static void DownloadFromGpuTexture(SDL_GPUCopyPass* copyPass, SDL_GPUTextureRegion* source, SDL_GPUTextureTransferInfo* destination) => SDL_DownloadFromGPUTexture(copyPass, source, destination);

    public static void DrawGpuIndexedPrimitives(SDL_GPURenderPass* renderPass, uint numIndices, uint numInstances, uint firstIndex, int vertexOffset, uint firstInstance) =>
        SDL_DrawGPUIndexedPrimitives(renderPass, numIndices, numInstances, firstIndex, vertexOffset, firstInstance);

    public static void DrawGpuIndexedPrimitivesIndirect(SDL_GPURenderPass* renderPass, SDL_GPUBuffer* buffer, uint offset, uint drawCount) => SDL_DrawGPUIndexedPrimitivesIndirect(renderPass, buffer, offset, drawCount);

    public static void DrawGpuPrimitives(SDL_GPURenderPass* renderPass, uint numVertices, uint numInstances, uint firstVertex, uint firstInstance) =>
        SDL_DrawGPUPrimitives(renderPass, numVertices, numInstances, firstVertex, firstInstance);

    public static void DrawGpuPrimitivesIndirect(SDL_GPURenderPass* renderPass, SDL_GPUBuffer* buffer, uint offset, uint drawCount) => SDL_DrawGPUPrimitivesIndirect(renderPass, buffer, offset, drawCount);
    public static void EndGpuComputePass(SDL_GPUComputePass* computePass) => SDL_EndGPUComputePass(computePass);
    public static void EndGpuCopyPass(SDL_GPUCopyPass* copyPass) => SDL_EndGPUCopyPass(copyPass);
    public static void EndGpuRenderPass(SDL_GPURenderPass* renderPass) => SDL_EndGPURenderPass(renderPass);
    public static void GenerateMipmapsForGpuTexture(SDL_GPUCommandBuffer* commandBuffer, SDL_GPUTexture* texture) => SDL_GenerateMipmapsForGPUTexture(commandBuffer, texture);
    public static string GetGpuDeviceDriver(SDL_GPUDevice* device) => SDL_GetGPUDeviceDriver(device) ?? string.Empty;
    public static string GetGpuDriver(int index) => SDL_GetGPUDriver(index) ?? string.Empty;
    public static SDL_GPUShaderFormat GetGpuShaderFormats(SDL_GPUDevice* device) => SDL_GetGPUShaderFormats(device);
    public static SDL_GPUTextureFormat GetGpuSwapchainTextureFormat(SDL_GPUDevice* device, SDL_Window* window) => SDL_GetGPUSwapchainTextureFormat(device, window);
    public static int GetNumGpuDrivers() => SDL_GetNumGPUDrivers();
    public static bool GpuSupportsProperties(SDL_PropertiesID props) => SDL_GPUSupportsProperties(props);
    public static bool GpuSupportsShaderFormats(SDL_GPUShaderFormat formatFlags, byte* name) => SDL_GPUSupportsShaderFormats(formatFlags, name);
    public static bool GpuSupportsShaderFormats(SDL_GPUShaderFormat formatFlags, string name) => SDL_GPUSupportsShaderFormats(formatFlags, name);
    public static uint GpuTextureFormatTexelBlockSize(SDL_GPUTextureFormat format) => SDL_GPUTextureFormatTexelBlockSize(format);
    public static bool GpuTextureSupportsFormat(SDL_GPUDevice* device, SDL_GPUTextureFormat format, SDL_GPUTextureType type, SDL_GPUTextureUsageFlags usage) => SDL_GPUTextureSupportsFormat(device, format, type, usage);
    public static bool GpuTextureSupportsSampleCount(SDL_GPUDevice* device, SDL_GPUTextureFormat format, SDL_GPUSampleCount sampleCount) => SDL_GPUTextureSupportsSampleCount(device, format, sampleCount);
    public static void InsertGpuDebugLabel(SDL_GPUCommandBuffer* commandBuffer, byte* text) => SDL_InsertGPUDebugLabel(commandBuffer, text);
    public static void InsertGpuDebugLabel(SDL_GPUCommandBuffer* commandBuffer, string text) => SDL_InsertGPUDebugLabel(commandBuffer, text);
    public static IntPtr MapGpuTransferBuffer(SDL_GPUDevice* device, SDL_GPUTransferBuffer* transferBuffer, bool cycle) => SDL_MapGPUTransferBuffer(device, transferBuffer, cycle);
    public static void PopGpuDebugGroup(SDL_GPUCommandBuffer* commandBuffer) => SDL_PopGPUDebugGroup(commandBuffer);
    public static void PushGpuComputeUniformData(SDL_GPUCommandBuffer* commandBuffer, uint slotIndex, IntPtr data, uint length) => SDL_PushGPUComputeUniformData(commandBuffer, slotIndex, data, length);
    public static void PushGpuDebugGroup(SDL_GPUCommandBuffer* commandBuffer, byte* name) => SDL_PushGPUDebugGroup(commandBuffer, name);
    public static void PushGpuDebugGroup(SDL_GPUCommandBuffer* commandBuffer, string name) => SDL_PushGPUDebugGroup(commandBuffer, name);
    public static void PushGpuFragmentUniformData(SDL_GPUCommandBuffer* commandBuffer, uint slotIndex, IntPtr data, uint length) => SDL_PushGPUFragmentUniformData(commandBuffer, slotIndex, data, length);
    public static void PushGpuVertexUniformData(SDL_GPUCommandBuffer* commandBuffer, uint slotIndex, IntPtr data, uint length) => SDL_PushGPUVertexUniformData(commandBuffer, slotIndex, data, length);
    public static bool QueryGpuFence(SDL_GPUDevice* device, SDL_GPUFence* fence) => SDL_QueryGPUFence(device, fence);
    public static void ReleaseGpuBuffer(SDL_GPUDevice* device, SDL_GPUBuffer* buffer) => SDL_ReleaseGPUBuffer(device, buffer);
    public static void ReleaseGpuComputePipeline(SDL_GPUDevice* device, SDL_GPUComputePipeline* computePipeline) => SDL_ReleaseGPUComputePipeline(device, computePipeline);
    public static void ReleaseGpuFence(SDL_GPUDevice* device, SDL_GPUFence* fence) => SDL_ReleaseGPUFence(device, fence);
    public static void ReleaseGpuGraphicsPipeline(SDL_GPUDevice* device, SDL_GPUGraphicsPipeline* graphicsPipeline) => SDL_ReleaseGPUGraphicsPipeline(device, graphicsPipeline);
    public static void ReleaseGpuSampler(SDL_GPUDevice* device, SDL_GPUSampler* sampler) => SDL_ReleaseGPUSampler(device, sampler);
    public static void ReleaseGpuShader(SDL_GPUDevice* device, SDL_GPUShader* shader) => SDL_ReleaseGPUShader(device, shader);
    public static void ReleaseGpuTexture(SDL_GPUDevice* device, SDL_GPUTexture* texture) => SDL_ReleaseGPUTexture(device, texture);
    public static void ReleaseGpuTransferBuffer(SDL_GPUDevice* device, SDL_GPUTransferBuffer* transferBuffer) => SDL_ReleaseGPUTransferBuffer(device, transferBuffer);
    public static void ReleaseWindowFromGpuDevice(SDL_GPUDevice* device, SDL_Window* window) => SDL_ReleaseWindowFromGPUDevice(device, window);
    public static bool SetGpuAllowedFramesInFlight(SDL_GPUDevice* device, uint allowedFramesInFlight) => SDL_SetGPUAllowedFramesInFlight(device, allowedFramesInFlight);
    public static void SetGpuBlendConstants(SDL_GPURenderPass* renderPass, SDL_FColor blendConstants) => SDL_SetGPUBlendConstants(renderPass, blendConstants);
    public static void SetGpuBufferName(SDL_GPUDevice* device, SDL_GPUBuffer* buffer, byte* text) => SDL_SetGPUBufferName(device, buffer, text);
    public static void SetGpuBufferName(SDL_GPUDevice* device, SDL_GPUBuffer* buffer, string text) => SDL_SetGPUBufferName(device, buffer, text);
    public static void SetGpuScissor(SDL_GPURenderPass* renderPass, SDL_Rect* scissor) => SDL_SetGPUScissor(renderPass, scissor);
    public static void SetGpuStencilReference(SDL_GPURenderPass* renderPass, byte reference) => SDL_SetGPUStencilReference(renderPass, reference);

    public static bool SetGpuSwapchainParameters(SDL_GPUDevice* device, SDL_Window* window, SDL_GPUSwapchainComposition swapchainComposition, SDL_GPUPresentMode presentMode) =>
        SDL_SetGPUSwapchainParameters(device, window, swapchainComposition, presentMode);

    public static void SetGpuTextureName(SDL_GPUDevice* device, SDL_GPUTexture* texture, byte* text) => SDL_SetGPUTextureName(device, texture, text);
    public static void SetGpuTextureName(SDL_GPUDevice* device, SDL_GPUTexture* texture, string text) => SDL_SetGPUTextureName(device, texture, text);
    public static void SetGpuViewport(SDL_GPURenderPass* renderPass, SDL_GPUViewport* viewport) => SDL_SetGPUViewport(renderPass, viewport);
    public static bool SubmitGpuCommandBuffer(SDL_GPUCommandBuffer* commandBuffer) => SDL_SubmitGPUCommandBuffer(commandBuffer);
    public static SDL_GPUFence* SubmitGpuCommandBufferAndAcquireFence(SDL_GPUCommandBuffer* commandBuffer) => SDL_SubmitGPUCommandBufferAndAcquireFence(commandBuffer);
    public static void UnmapGpuTransferBuffer(SDL_GPUDevice* device, SDL_GPUTransferBuffer* transferBuffer) => SDL_UnmapGPUTransferBuffer(device, transferBuffer);
    public static void UploadToGpuBuffer(SDL_GPUCopyPass* copyPass, SDL_GPUTransferBufferLocation* source, SDL_GPUBufferRegion* destination, bool cycle) => SDL_UploadToGPUBuffer(copyPass, source, destination, cycle);
    public static void UploadToGpuTexture(SDL_GPUCopyPass* copyPass, SDL_GPUTextureTransferInfo* source, SDL_GPUTextureRegion* destination, bool cycle) => SDL_UploadToGPUTexture(copyPass, source, destination, cycle);

    public static bool WaitAndAcquireGpuSwapchainTexture(SDL_GPUCommandBuffer* commandBuffer, SDL_Window* window, SDL_GPUTexture** swapchainTexture, uint* swapchainTextureWidth, uint* swapchainTextureHeight) =>
        SDL_WaitAndAcquireGPUSwapchainTexture(commandBuffer, window, swapchainTexture, swapchainTextureWidth, swapchainTextureHeight);

    public static bool WaitForGpuFences(SDL_GPUDevice* device, bool waitAll, SDL_GPUFence** fences, uint numFences) => SDL_WaitForGPUFences(device, waitAll, fences, numFences);
    public static bool WaitForGpuIdle(SDL_GPUDevice* device) => SDL_WaitForGPUIdle(device);
    public static bool WaitForGpuSwapchain(SDL_GPUDevice* device, SDL_Window* window) => SDL_WaitForGPUSwapchain(device, window);
    public static bool WindowSupportsGpuPresentMode(SDL_GPUDevice* device, SDL_Window* window, SDL_GPUPresentMode presentMode) => SDL_WindowSupportsGPUPresentMode(device, window, presentMode);

    public static bool WindowSupportsGpuSwapchainComposition(SDL_GPUDevice* device, SDL_Window* window, SDL_GPUSwapchainComposition swapchainComposition) =>
        SDL_WindowSupportsGPUSwapchainComposition(device, window, swapchainComposition);
}