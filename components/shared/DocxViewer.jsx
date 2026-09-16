'use client';

import { useEffect, useRef } from 'react';
import * as docx from 'docx-preview';

export default function DocxViewer({ base64Data, fileName, onClose, onExport }) {
  const containerRef = useRef(null);

  useEffect(() => {
    if (base64Data && containerRef.current) {
      try {
        const byteCharacters = atob(base64Data);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
          byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        const blob = new Blob([byteArray], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });

        docx.renderAsync(blob, containerRef.current, null, {
          className: 'docx-viewer-content',
          inWrapper: true,     
          ignoreWidth: false,  
          ignoreHeight: false, 
          breakPages: true,   
          useWindowForVml: true,
          experimental: true,   
          debug: false
        });
      } catch (error) {
        console.error("An error occurred while rendering the DOCX file:", error);
      }
    }
  }, [base64Data]);

  return (
    <div className="fixed inset-0 z-[110] bg-gray-900/80 flex flex-col backdrop-blur-sm animate-in fade-in duration-200">
      {/* Toolbar */}
      <div className="h-14 bg-white flex items-center justify-between px-6 shadow-md z-10">
        <div className="flex items-center gap-3">
          <svg className="w-6 h-6 text-blue-600" fill="currentColor" viewBox="0 0 24 24"><path d="M14 2H6c-1.1 0-1.99.9-1.99 2L4 20c0 1.1.89 2 1.99 2h12c1.1 0 2-.9 2-2V8l-6-6zm2 16H8v-2h8v2zm0-4H8v-2h8v2zm-3-5V3.5L18.5 9H13z"/></svg>
          <span className="font-semibold text-gray-800">{fileName || 'Document Preview'}</span>
        </div>
        <div className="flex gap-3">
          <button 
            onClick={onExport} 
            className="px-5 py-1.5 bg-[#028497] text-white text-sm font-medium rounded shadow hover:bg-[#117180] transition-colors flex items-center gap-2"
          >
            <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2"><path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4M7 10l5 5 5-5M12 15V3"/></svg>
            Export
          </button>
          <button 
            onClick={onClose} 
            className="px-5 py-1.5 bg-gray-200 text-gray-800 text-sm font-medium rounded hover:bg-gray-300 transition-colors"
          >
            Close
          </button>
        </div>
      </div>
      
      {/* Document Container */}
      <div className="flex-1 overflow-auto bg-gray-100/80 p-4 sm:p-8 flex justify-center items-start">
        <div 
          ref={containerRef} 
          className="bg-white shadow-2xl rounded-sm overflow-hidden" 
        />
      </div>
    </div>
  );
}