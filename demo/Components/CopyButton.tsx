import React from "react";

export default function CopyButton ({ text  }) {

    const [showCopied, setShowCopied] = React.useState(false);

    const copyToClipboard = () => {
        setShowCopied(true);
        navigator.clipboard.writeText(text);
    };

    return (
        <button
            className={`copy-button ${showCopied ? "ok color bg border" : ""}`}
            onClick={copyToClipboard}
            onMouseLeave={() => setShowCopied(false)}
            >
            {showCopied ? "Code Copied!" : "Copy"}
        </button>
    );
}
