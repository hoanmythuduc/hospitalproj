import React, { useState, useEffect, useRef } from 'react';
import { dynamicApi } from "../../api/api";
import TreeCheckbox from './TreeCheckbox';
import { parseMatrixToTreeAndIds, buildPayloadFromFlatIds, parsePayloadToFlatIds } from '../../utils/permissionUtils';

export default function PermissionField({ apiEndpoint, matrixId = 0, externalPayload = null, onChange, isReadonly = false }) {
  const [uiTree, setUiTree] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [flatValue, setFlatValue] = useState([]);
  const mapsRef = useRef({ menuMap: {}, actionMap: {} });

  useEffect(() => {
    if (!apiEndpoint) {
      setIsLoading(false);
      return;
    }
    const fetchMatrix = async () => {
      setIsLoading(true);
      const response = await dynamicApi.getAll(`${apiEndpoint}${matrixId}`);
      
      if (!response.error && response.data) {
        const { menuMap, actionMap, uiTree: newTree, initialFlatIds } = parseMatrixToTreeAndIds(response.data);
        mapsRef.current = { menuMap, actionMap };
        setUiTree(newTree); 
        
        if (!externalPayload || externalPayload.length === 0) {
          setFlatValue(initialFlatIds);
          if (!isReadonly) {
            const initialPayload = buildPayloadFromFlatIds(initialFlatIds, menuMap, actionMap);
            onChange(initialPayload);
          }
        } else {
          const mappedFlatIds = parsePayloadToFlatIds(externalPayload);
          setFlatValue(mappedFlatIds);
          if (!isReadonly) {
            const payload = buildPayloadFromFlatIds(mappedFlatIds, menuMap, actionMap);
            if (JSON.stringify(payload) !== JSON.stringify(externalPayload)) {
              onChange(payload);
            }
          }
        }
      }
      setIsLoading(false);
    };
    fetchMatrix();
  }, [apiEndpoint, matrixId]); 

  useEffect(() => {
    if (Object.keys(mapsRef.current.menuMap).length === 0) return;

    if (externalPayload && externalPayload.length > 0) {
      const mappedFlatIds = parsePayloadToFlatIds(externalPayload);
      setFlatValue(mappedFlatIds);
      
      if (!isReadonly) {
        const payload = buildPayloadFromFlatIds(mappedFlatIds, mapsRef.current.menuMap, mapsRef.current.actionMap);
        if (JSON.stringify(payload) !== JSON.stringify(externalPayload)) {
          onChange(payload);
        }
      }
    } else {
      setFlatValue([]);
    }
  }, [externalPayload, isReadonly, uiTree]); 

  const handleTreeChange = (newFlatIds) => {
    setFlatValue(newFlatIds); 
    const payload = buildPayloadFromFlatIds(newFlatIds, mapsRef.current.menuMap, mapsRef.current.actionMap);
    onChange(payload);
  };

  if (isLoading) return <p className="text-sm text-gray-400 p-4 font-medium italic">Loading permissions...</p>;

  return (
    <div className={`w-full border border-gray-300 rounded p-5 max-h-[300px] overflow-y-auto shadow-inner ${isReadonly ? 'bg-gray-50 opacity-90' : 'bg-white'}`}>
      <div className={isReadonly ? 'pointer-events-none' : ''}>
        <TreeCheckbox treeData={uiTree} value={flatValue} onChange={handleTreeChange} isReadonly={isReadonly} />
      </div>
    </div>
  );
}