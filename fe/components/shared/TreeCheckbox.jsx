import React, { useState, useMemo } from 'react';
import { Icons } from '../../utils/icon.js';

export default function TreeCheckbox({ treeData = [], value = [], onChange, isReadonly = false }) {
  const { nodeMap, descendantMap } = useMemo(() => {
    const nMap = {};
    const dMap = {};
    const traverse = (node) => {
      nMap[node.id] = node; 
      let descendants = [];
      if (node.children && node.children.length > 0) {
        node.children.forEach(child => {
          descendants.push(child.id);
          descendants = descendants.concat(traverse(child));
        });
      }
      dMap[node.id] = descendants;
      return descendants;
    };

    treeData.forEach(rootNode => traverse(rootNode));

    return { nodeMap: nMap, descendantMap: dMap };
  }, [treeData]);

  const handleCheck = (node, isChecked, ancestorIds) => {
    if (isReadonly) return; 

    let newSet = new Set(value);

    if (isChecked) {
      newSet.add(node.id);
      const descendants = descendantMap[node.id] || [];
      descendants.forEach(id => newSet.add(id));
      
      ancestorIds.forEach(id => newSet.add(id));
    } else {
      newSet.delete(node.id);
      
      const descendants = descendantMap[node.id] || [];
      descendants.forEach(id => newSet.delete(id));
      
      const reversedAncestors = [...ancestorIds].reverse();
      for (let ancestorId of reversedAncestors) {
        const ancestorNode = nodeMap[ancestorId];
        
        if (ancestorNode && ancestorNode.children) {
          const hasCheckedChild = ancestorNode.children.some(child => newSet.has(child.id));
          if (!hasCheckedChild) newSet.delete(ancestorId);
          else break;
        }
      }
    }
    onChange(Array.from(newSet));
  };

  return (
    <div className="flex flex-col">
      {treeData.map(rootNode => (
        <TreeNode 
          key={rootNode.id} 
          node={rootNode} 
          level={0} 
          ancestors={[]} 
          checkedIds={value} 
          onCheck={handleCheck}
          isReadonly={isReadonly} 
        />
      ))}
    </div>
  );
}

const TreeNode = React.memo(({ node, level = 0, ancestors = [], checkedIds = [], onCheck, isReadonly }) => {
  const [isExpanded, setIsExpanded] = useState(true);
  const hasChildren = node.children && node.children.length > 0;
  const isChecked = checkedIds.includes(node.id);

  return (
    <div className="flex flex-col">
      <div className="flex items-center py-1.5 hover:bg-gray-50 transition-colors" style={{ paddingLeft: `${level * 24}px` }}>
        <div className="w-5 flex items-center justify-center cursor-pointer" onClick={() => hasChildren && setIsExpanded(!isExpanded)}>
          {hasChildren && (
            <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" className={`text-gray-400 transition-transform ${isExpanded ? 'rotate-90' : ''}`}>
              <path d="M9 18l6-6-6-6" />
            </svg>
          )}
        </div>
        <input 
          type="checkbox" 
          checked={isChecked} 
          disabled={isReadonly}
          onChange={(e) => onCheck(node, e.target.checked, ancestors)} 
          className={`w-4 h-4 mr-3 rounded border-gray-300 focus:ring-[#00b074] transition-colors ${isReadonly ? 'cursor-not-allowed opacity-50 bg-gray-200 text-gray-400' : 'text-[#00b074] cursor-pointer'}`} 
        />
        <div className={`flex items-center gap-2 text-sm select-none ${isReadonly ? 'text-gray-500' : 'text-gray-700'}`}>
          {node.icon && Icons && Icons[node.icon]}
          <span className={node.isAction ? "italic text-gray-500" : "font-medium"}>{node.label}</span>
        </div>
      </div>

      {isExpanded && hasChildren && (
        <div className="flex flex-col">
          {node.children.map((child) => (
            <TreeNode 
              key={child.id} 
              node={child} 
              level={level + 1} 
              ancestors={[...ancestors, node.id]} 
              checkedIds={checkedIds} 
              onCheck={onCheck}
              isReadonly={isReadonly}
            />
          ))}
        </div>
      )}
    </div>
  );
});