# @renderx-plugins/host-sdk

Host SDK for RenderX plugins - provides conductor, event routing, and component mapping APIs.

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

## Peer Dependencies

- `musical-conductor`: The orchestration engine
- `react`: React 18+ for hook-based APIs

## License

MIT
