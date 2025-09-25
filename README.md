# @renderx-plugins/host-sdk

Host SDK for RenderX plugins - provides conductor, event routing, component mapping, inventory management, and CSS registry APIs.

## Installation

```bash
npm install @renderx-plugins/host-sdk
```

## Usage

This SDK provides the core APIs that RenderX plugins use to interact with the host application:

### Conductor API

```typescript
import { useConductor } from '@renderx-plugins/host-sdk';

function MyPlugin() {
  const conductor = useConductor();

  // Play a sequence
  const result = await conductor.play('pluginId', 'sequenceId', data);
}
```

### Interaction Resolution

```typescript
import { resolveInteraction } from '@renderx-plugins/host-sdk';

// Resolve interaction to plugin/sequence IDs
const route = resolveInteraction('app.ui.theme.toggle');
// Returns: { pluginId: 'HeaderThemePlugin', sequenceId: 'header-ui-theme-toggle-symphony' }
```

### Component Mapping

```typescript
import { getTagForType, mapJsonComponentToTemplate } from '@renderx-plugins/host-sdk';

// Map component types to HTML tags
const tag = getTagForType('button'); // 'button'

// Convert JSON component to template
const template = mapJsonComponentToTemplate(jsonComponent);
```

### Feature Flags

```typescript
import { isFlagEnabled, getFlagMeta } from '@renderx-plugins/host-sdk';

// Check if feature is enabled
const enabled = isFlagEnabled('new-feature');

// Get flag metadata
const meta = getFlagMeta('new-feature');
```

### Plugin Manifest

```typescript
import { getPluginManifest } from '@renderx-plugins/host-sdk';

// Get plugin manifest data
const manifest = getPluginManifest();
```

### Inventory API

The Inventory API provides access to component inventory management for external plugins:

```typescript
import {
  listComponents,
  getComponentById,
  onInventoryChanged,
  Inventory
} from '@renderx-plugins/host-sdk';
import type { ComponentSummary, Component } from '@renderx-plugins/host-sdk';

// List all available components
const components: ComponentSummary[] = await listComponents();

// Get detailed component information
const component: Component | null = await getComponentById('my-component-id');

// Subscribe to inventory changes
const unsubscribe = onInventoryChanged((components: ComponentSummary[]) => {
  console.log('Inventory updated:', components);
});

// Unsubscribe when done
unsubscribe();

// Alternative: Use the convenience object
const components = await Inventory.listComponents();
const component = await Inventory.getComponentById('my-component-id');
```

### CSS Registry API

The CSS Registry API provides CSS class management capabilities:

```typescript
import {
  hasClass,
  createClass,
  updateClass,
  onCssChanged,
  CssRegistry
} from '@renderx-plugins/host-sdk';
import type { CssClassDef } from '@renderx-plugins/host-sdk';

// Check if a CSS class exists
const exists: boolean = await hasClass('my-custom-class');

// Create a new CSS class
const classDef: CssClassDef = {
  name: 'my-custom-class',
  rules: '.my-custom-class { color: blue; background: white; }',
  source: 'my-plugin',
  metadata: { version: '1.0' }
};
await createClass(classDef);

// Update an existing CSS class
await updateClass('my-custom-class', {
  name: 'my-custom-class',
  rules: '.my-custom-class { color: red; background: white; }'
});

// Subscribe to CSS changes
const unsubscribe = onCssChanged((classes: CssClassDef[]) => {
  console.log('CSS registry updated:', classes);
});

// Alternative: Use the convenience object
const exists = await CssRegistry.hasClass('my-class');
await CssRegistry.createClass(classDef);
```

## Node.js/SSR Support

All APIs work seamlessly in Node.js environments with mock implementations. The facades automatically detect the environment and provide appropriate fallbacks:

```typescript
// Works in both browser and Node.js
const components = await listComponents(); // Returns empty array in Node.js
const hasMyClass = await hasClass('test'); // Returns false in Node.js

// Test utilities for Node.js environments
import { setMockInventory, setMockCssClass } from '@renderx-plugins/host-sdk';

// Set up mock data for testing
setMockInventory([{ id: 'test', name: 'Test Component' }]);
setMockCssClass({ name: 'test-class', rules: '.test-class { color: red; }' });
```

## Peer Dependencies

- `musical-conductor`: The orchestration engine
- `react`: React 18+ for hook-based APIs


## Host primitives (advanced)

For host applications that want a thin shell, internal primitives are now available via subpath exports under `core/*`:

```typescript
import { initConductor } from '@renderx-plugins/host-sdk/core/conductor';
import { EventRouter } from '@renderx-plugins/host-sdk/core/events/EventRouter';
```

Notes:
- These APIs are intended for host integration and may assume a browser-like environment unless otherwise documented.
- JSON sequence/catalog loading paths are discovered at runtime; see `core/environment/env.ts` for `HOST_ARTIFACTS_DIR` discovery used outside the browser.

## License

MIT
