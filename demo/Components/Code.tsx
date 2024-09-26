import React, { useEffect } from "react";
import Prism from "prismjs";
import CopyButton from "./CopyButton";
import "prismjs/components/prism-fsharp";


export default function Code({ code, language }) {
    useEffect(() => {
        Prism.highlightAll();
    }, []);

    return (
        <figure className="code-snippet">
            <pre>
            <CopyButton text={code} />
                <code className={`language-${language}`}>{code}</code>
            </pre>
        </figure>
    );
}
