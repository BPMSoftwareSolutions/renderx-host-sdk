# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.3.0] - 2025-09-10

### Added

- **Inventory API**: New facade for component inventory management
  - `listComponents()`: List all available components with summary information
  - `getComponentById(id)`: Get detailed component information by ID
  - `onInventoryChanged(callback)`: Subscribe to inventory changes
  - `Inventory` object: Convenience object containing all inventory methods
  - Full TypeScript support with `ComponentSummary`, `Component`, and `InventoryAPI` types

- **CSS Registry API**: New facade for CSS class management
  - `hasClass(name)`: Check if a CSS class exists
  - `createClass(def)`: Create a new CSS class
  - `updateClass(name, def)`: Update an existing CSS class
  - `onCssChanged(callback)`: Subscribe to CSS registry changes
  - `CssRegistry` object: Convenience object containing all CSS registry methods
  - Full TypeScript support with `CssClassDef` and `CssRegistryAPI` types

### Features

- **Node/SSR Support**: Both APIs work seamlessly in Node.js environments with mock implementations
- **Host Delegation**: APIs delegate to host implementations when available, falling back gracefully
- **Observer Pattern**: Both APIs support change observers with proper unsubscribe functionality
- **Error Handling**: Comprehensive error handling with graceful fallbacks and informative warnings
- **Test Utilities**: Mock functions for testing in Node/SSR environments

### Breaking Changes

None. This release is fully backwards compatible.

### Upgrade Notes

- All new API methods are asynchronous and return Promises. Consumers should treat these methods as async operations.
- The APIs are designed to work without host implementations, making them safe to use in any environment.
- Observer callbacks should handle potential errors gracefully as the SDK will log warnings but continue operation.

### Technical Details

- APIs follow the established facade pattern used by other SDK components
- Full unit test coverage with 56 passing tests
- TypeScript definitions included in global `Window.RenderX` interface
- Compatible with existing build and test infrastructure

## [0.1.1] - 2025-09-09

### Fixed

- Export `setPluginManifest` function in public API
- Correct test imports to align with repository layout
- Update repository URL in package.json

## [0.1.0] - 2025-09-09

### Added

- Initial release of `@renderx-plugins/host-sdk`
- Conductor API with `useConductor` hook
- Event routing with `EventRouter`
- Interaction resolution with `resolveInteraction`
- Feature flags management
- Component mapping utilities
- Plugin manifest access
- Comprehensive test suite with Vitest
- TypeScript support with full type definitions
