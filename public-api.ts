// Standalone public surface for @renderx/host-sdk
export { useConductor } from "./conductor.js";
export type { ConductorClient } from "./conductor.js";
export { EventRouter } from "./EventRouter.js";
export { resolveInteraction } from "./interactionManifest.js";
export { isFlagEnabled, getFlagMeta, getAllFlags, getUsageLog, setFlagOverride, clearFlagOverrides } from "./feature-flags.js";
export { getTagForType, computeTagFromJson } from "./component-mapper.js";
export { mapJsonComponentToTemplate } from "./jsonComponent.mapper.js";
export { getPluginManifest, getCachedPluginManifest, setPluginManifest } from "./pluginManifest.js";

// Inventory API
export { listComponents, getComponentById, onInventoryChanged, Inventory } from "./inventory.js";
export type { ComponentSummary, Component, InventoryAPI } from "./types.js";

// CSS Registry API
export { hasClass, createClass, updateClass, onCssChanged, CssRegistry } from "./cssRegistry.js";
export type { CssClassDef, CssRegistryAPI } from "./types.js";