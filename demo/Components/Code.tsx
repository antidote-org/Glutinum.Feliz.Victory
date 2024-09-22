import React, { useEffect } from "react";
import Prism from "prismjs";

import "prismjs/components/prism-fsharp";

export default function Code({ code, language }) {
    useEffect(() => {
        Prism.highlightAll();
        // Prism.
    }, []);
    return (
        <figure style={{ marginTop: 0, overflow: "auto", maxHeight: "400px"}}>
            <pre>
                <code className={`language-${language}`}>{code}</code>
            </pre>
        </figure>
    );
}
