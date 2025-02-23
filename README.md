# BurnJsPopup

BurnJsPopup is a lightweight JavaScript library for creating customizable popup windows. It is designed to be easy to use and integrate into any web project.

## Features

- Lightweight and fast
- Customizable appearance and behavior
- Easy to integrate
- No dependencies

## Installation

You can install BurnJsPopup via npm:

```bash
npm install burnjspopup
```

Or include it directly in your HTML:

```html
<script src="path/to/burnjspopup.js"></script>
<link rel="stylesheet" href="path/to/burnjspopup.css">
```

## Usage

Here is a basic example of how to use BurnJsPopup:

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>BurnJsPopup Example</title>
    <link rel="stylesheet" href="path/to/burnjspopup.css">
</head>
<body>
    <button id="openPopup">Open Popup</button>

    <script type="module">
        import * as popup from './js/burnJsPopup.js';
    
        function openPopup() {
            
            const popupWindow = popup.createPopup();

            const innerPopup = document.createElement('div');
            innerPopup.textContent = 'Hello, world! I would like to give you some information';

            innerPopup.addEventListener('click', () => {
                for (var n =0; n < 50; n++) {
                innerPopup.textContent += 'Hello, world! I would like to give you some information';
                }
            });

            popupWindow.htmlContent.appendChild(innerPopup);

            // Add close button
            const closeButton = document.createElement('button');
            closeButton.textContent = 'Close';
            closeButton.addEventListener('click', () => {
                popupWindow.closePopup(popupWindow);
            });
            popupWindow.htmlContent.appendChild(closeButton);
        }

        window.openPopup = openPopup;
        
    </script>
</body>
</html>
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request on GitHub.

